using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private Vector2 mouseInput;
    
    public static PlayerController instance;
    
    public Rigidbody2D theRB;
    public float moveSpeed = 5f;
    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnim;
    public Animator anim;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    public bool hasDied = false;

    public GameObject ammoBox, healthBox;
    public Text healthText, ammoText;
    
    [SerializeField] private Text enemyKilledText;
    [SerializeField] public GameObject enemyKilledBox;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";

        ammoText.text = currentAmmo.ToString();
    }

    void Update()
    {
        if (!hasDied)
        {
            // **Player movement control**
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            
            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;
    
            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

            // **Player view control*
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
    
            /*
             * The reason why we don't change the rotations of x and y,
             * and remove Mouse input x from rotation z is related to the transform in which the player is actually located.
             */
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                transform.rotation.eulerAngles.z - mouseInput.x
            );
    
            //  **Player's up and down angle range settling**
            float maxAngle = 180;
            float minAngle = 0;
            
            // Getting player's mouse y input
            Vector3 rotationAmount = viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);
            
            // Clamping xyz rotations
            viewCam.transform.localRotation = Quaternion.Euler(rotationAmount.x, Mathf.Clamp(rotationAmount.y, minAngle, maxAngle),
                rotationAmount.z);

            // **Shooting**
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmo > 0)
                {
                    AudioManager.Instance.PlayGunShot();
                    // Here (.5f, .5f, 0f) the viewpoint is set to the middle of the screen
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;
                    
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("Player looking at " + hit.transform.parent.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);
    
                        if (hit.transform.parent.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<Enemy>().TakeDamage();
                        }
                    }
                    else
                    {
                        //Debug.Log("Player looking at nothing");
                    }
                    currentAmmo--;
                    gunAnim.SetTrigger("Shoot");
                    UpdateAmmoUI();
                }
            }

            if (moveInput != Vector2.zero) { anim.SetBool("isMoving",true); }
            else { anim.SetBool("isMoving",false); }
        }
        
        switch (Enemy.deadEnemyCount)
        {
            case 6:
                enemyKilledBox.SetActive(false);
                break;
        }
        
        enemyKilledText.text = Enemy.deadEnemyCount.ToString();
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            enemyKilledBox.SetActive(false);
            ammoBox.SetActive(false);
            healthBox.SetActive(false);
            hasDied = true;
            currentHealth = 0;
            Enemy.deadEnemyCount = 0;
        }
        
        healthText.text = currentHealth.ToString() + "%";

        if (!hasDied)
        {
            AudioManager.Instance.PlayPlayerHurt();
        }

    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        healthText.text = currentHealth.ToString() + "%";
    }


    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }

}
