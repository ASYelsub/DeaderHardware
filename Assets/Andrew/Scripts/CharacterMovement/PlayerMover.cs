using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    CharacterController CC;

    public Vector3 moveDirection;
    Vector3 rDir; //Camera Right Direction
    Vector3 fDir; //Camera Forward Direction
    Vector3 uDir; //Camera Up Direction

    public Transform CamTransform;

    public float walkSpeed;
    public float grav;

    bool grounded;

    public Transform body;
    Vector3 lookLerp;

    Vector3 spawnPos;

    void Start()
    {
        spawnPos = transform.position;
        CC = GetComponent<CharacterController>();
        lookLerp = transform.position+transform.forward;
        
        //vv SET THIS TO THE CAMERA PREFAB LATER vv
        CamTransform = Camera.main.transform;

    }

    bool moveRelative;
    public float rotSpeed;

    void Update()
    {
        

        if (moveRelative)
        {
            relativeMovement();
        }
        else
        {
            tankMovement();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            moveRelative = !moveRelative;
            CC.enabled = false;
            transform.position = spawnPos;
            CC.enabled = true;
        }
    }

    float yRot;
    Vector3 tankXZ;

    void tankMovement()
    {
        body.localRotation = Quaternion.Euler(0,0,0);

        yRot += Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Euler(0,yRot,0);

        tankXZ = transform.forward * Input.GetAxis("Vertical") * walkSpeed;

        moveDirection = new Vector3(tankXZ.x, moveDirection.y, tankXZ.z);

        if (!grounded) { moveDirection.y -= grav; }
        else { moveDirection.y = 0f; }

        CC.Move(moveDirection * Time.deltaTime);

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            grounded = hit.distance < 1.25f;
            if (hit.distance < 1.25f)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + 1f, transform.position.z);
            }
        }
        else
        {
            grounded = false;
        }
    }

    void relativeMovement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical")); //grab WASD / ARROW values  

        moveDirection.x *= walkSpeed;
        moveDirection.z *= walkSpeed; // set the speed of walking (not falling) axis

        if (Input.GetAxisRaw("Horizontal") == 0) //only change relative moveDirection values when you take your hands off the keyboard. this is to prevent weird movement with camera switches.
        {
            moveDirection.x = 0;
            rDir = CamTransform.right;
            rDir.y = 0;
            rDir.Normalize();
        }

        if (Input.GetAxisRaw("Vertical") == 0) //only change relative moveDirection values when you take your hands off the keyboard. this is to prevent weird movement with camera switches.
        {
            moveDirection.z = 0;
            fDir = CamTransform.forward;
            fDir.y = 0;//set the y value to 0, so the player doesnt fly up in the event of a tilted camera
            fDir.Normalize(); //normalize to keep speed constant in efent of tilted camera
        }

        if (!grounded) { moveDirection.y -= grav; }
        else { moveDirection.y = 0f; }
        uDir = Vector3.up;

        moveDirection = (moveDirection.x * rDir) + (moveDirection.y * uDir) + (moveDirection.z * fDir); //make movement relative to camera orietation

        if (new Vector3(moveDirection.x, 0, moveDirection.z).magnitude > 0)
        {
            lookLerp = Vector3.Lerp(lookLerp, body.position + new Vector3(moveDirection.x, 0, moveDirection.z), Time.deltaTime * 15);
            body.LookAt(lookLerp);
        }

        CC.Move(moveDirection * Time.deltaTime); // move the character controller

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            grounded = hit.distance < 1.25f;
            if (hit.distance < 1.25f)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + 1f, transform.position.z);
            }
        }
        else
        {
            grounded = false;
        }
    }


}
