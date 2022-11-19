using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
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
                }
                else
                {
                    Debug.Log("Player looking at nothing");
                }
                currentAmmo--;
            }

        }
        
    }
}
