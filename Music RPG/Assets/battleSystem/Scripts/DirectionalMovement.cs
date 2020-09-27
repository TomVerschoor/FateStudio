using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody theRB;
    public float jumpForce;
    public Transform cam;
    public float turnsmooth = 0.1f;
    float turn;
    private Vector3 direction;
    private float targetAngle;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    //
    // Comment first or second out and follow instructions
    //

    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        angle = Mathf.SmoothDampAngle(cam.eulerAngles.y, targetAngle, ref turn, turnsmooth);
        theRB.velocity = Quaternion.Euler(0,angle, 0) * direction;
        

        if (Input.GetButtonDown("Jump"))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }

    }
}