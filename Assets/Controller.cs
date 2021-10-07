//Basic control script with cursor settings

using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody rb;
    public static bool movementUnlocked = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (movementUnlocked)
        {
            //movement with input from keyboard
            Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            playerInput = transform.TransformDirection(playerInput);
            rb.MovePosition(rb.position + playerInput * Time.deltaTime * 3);
            
            //rotation with mouse movement
            transform.eulerAngles += new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0);
        }
    }
}