using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnsmooth = 0.1f;
    float turn;

    public Rigidbody rig;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    //
    // Comment first or second out and follow instructions
    //

    void Update()
    {

        //
        // First
        // Character controller on
        // Move with camera direction
        // Jumping does not work smooth
        //

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turn, turnsmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //
        // First end
        //

        //
        // Second
        // Character controller off
        // Move and jump
        // Moveing with camera direction needs to be added
        //


        //float hor = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //float ver = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //transform.Translate(hor, 0, ver);

        //
        // Second end
        //

        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

    }
}
