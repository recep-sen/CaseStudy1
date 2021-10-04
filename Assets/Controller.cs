using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player_camera;
    // Start is called before the first frame update
    void Start()
    {
          rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 player_input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + player_input * Time.deltaTime*3);
        Vector3 player_rotation = new Vector3(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"),0 );
        Quaternion deltaRotation = Quaternion.Euler(player_rotation * Time.fixedDeltaTime);
        player_camera.transform.rotation *= deltaRotation;
    }
}