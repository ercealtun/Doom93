using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnim;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    private bool hasDied = false;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (!hasDied)
        {
            // Player movement control
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    
            Vector3 moveHorizontal = transform.up * -moveInput.x;
    
            Vector3 moveVertical = transform.right * moveInput.y;
    
            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;
    
            // Player view control
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
    
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                transform.rotation.eulerAngles.z - mouseInput.x
            );
    
            //  Player's up and down angle range settling
            float maxAngle = 180;
            float minAngle = 0;
            Vector3 RotationAmount = viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);
            viewCam.transform.localRotation = Quaternion.Euler(RotationAmount.x, Mathf.Clamp(RotationAmount.y, minAngle, maxAngle),
                RotationAmount.z);
            
            // Shooting
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmo > 0)
                {
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        //Debug.Log("Player looking at " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);
    
                        if (hit.transform.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                        }
                    }
                    else
                    {
                        //Debug.Log("Player looking at nothing");
                    }
                    currentAmmo--;
                    gunAnim.SetTrigger("Shoot");
                }
            }
        }
        else
        {
            unlockCursorEvent();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            hasDied = true;
        }
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void unlockCursorEvent()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Cursor unlocked");
    }
    

}
