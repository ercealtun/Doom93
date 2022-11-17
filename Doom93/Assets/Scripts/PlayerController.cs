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

    public Transform viewCam;
    
    
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


        float maxAngle = 160;
        float minAngle = 10;
        Vector3 RotAmount = viewCam.localRotation.eulerAngles + new Vector3 (0f, mouseInput.y, 0f);
        viewCam.localRotation = Quaternion.Euler(RotAmount.x, Mathf.Clamp(RotAmount.y, minAngle , maxAngle) , RotAmount.z);
        
    }
}
