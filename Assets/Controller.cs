using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player_camera;
    public static bool Movementunlocked = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Movementunlocked)
        {
            Vector3 player_input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            player_input = transform.TransformDirection(player_input);
            rb.MovePosition(rb.position + player_input * Time.deltaTime * 3);

            //Vector3 player_rotation = new Vector3(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"),0 );
            //Quaternion deltaRotation = Quaternion.Euler(player_rotation * Time.fixedDeltaTime*5);
            player_camera.transform.eulerAngles = player_camera.transform.eulerAngles + new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0);
            //Debug.Log(Input.GetAxisRaw("Mouse Y"));




            // Camera.main.transform.Rotate(-Input.GetAxisRaw("Mouse Y"), 0, 0, Space.Self);


            //Camera.main.transform.localEulerAngles = new Vector3(Mathf.Clamp(Camera.main.transform.localEulerAngles.x, -90, 90), 0, 0);





            //transform.eulerAngles = new Vector3(0, transform.eulerAngles.x + Input.GetAxisRaw("Mouse X"), 0);
        }
    }
}