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

    //public Transform CamTransform;

    public float walkSpeed = 0;
    public float maxWalkSpeed = 6;
    public float accel = 10;
    public float deccel = 10;
    public float grav = 40;

    public bool grounded;

    float tankRotation;
    public float rotationSpeed = 90;

    public float playerHeight = 1;
    public float rampSnapThreshold = .1f;

    public Vector3 lastGroundedPos;

    float startY;
    float respawnY;
    public float trigger_respawn_dist = 30f;
    private FMOD.Studio.EventInstance playerMoveAud;
    
    void Start()
    {
        //startY = CamTransform.position.y;
        respawnY = startY - trigger_respawn_dist;

        CC = GetComponent<CharacterController>();
        //CamTransform = Camera.main.transform;
        tankRotation = transform.rotation.eulerAngles.y;

        playerMoveAud = FMODUnity.RuntimeManager.CreateInstance("event:/PlayerMove");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(playerMoveAud, transform, GetComponent<Rigidbody>());
        playerMoveAud.start();
    }

    public void Update()
    {
        if (!ServicesLocator.DialogueManager.isShowing && !GameManager.invM.menuOn && !GameManager.settingsM.settingsActive)
        {
            tankRotation += Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, tankRotation, transform.rotation.eulerAngles.z);

            moveDirection = new Vector3(transform.forward.x, moveDirection.y, transform.forward.z);

            Physics.Raycast(transform.position, -transform.up, out RaycastHit hit);
            grounded = CC.isGrounded || (hit.collider != null && hit.distance < playerHeight + rampSnapThreshold && !hit.collider.isTrigger);

            if (grounded)
            {
                lastGroundedPos = transform.position;
                moveDirection.y = -.01f;
            }
            else
            {
                moveDirection.y -= grav * Time.deltaTime;
            }

            walkSpeed += Input.GetAxisRaw("Vertical") * accel * Time.deltaTime;
            if (Input.GetAxisRaw("Vertical") == 0) { walkSpeed -= (walkSpeed - 0) * deccel * Time.deltaTime; }

            walkSpeed = Mathf.Clamp(walkSpeed, -maxWalkSpeed, maxWalkSpeed);

            moveDirection.x *= walkSpeed;
            moveDirection.z *= walkSpeed;

            CC.Move(moveDirection * Time.deltaTime);

            

            if (hit.collider != null && hit.distance < playerHeight + rampSnapThreshold && !hit.collider.isTrigger) { new Vector3(transform.position.x, hit.point.y + playerHeight, transform.position.z); }
            if (transform.position.y < respawnY) { FallRespawn(); }
        }

        

    /*    if(ServicesLocator.DialogueManager.isShowing || GameManager.invM.menuOn || GameManager.settingsM.settingsActive)
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
        }

*/       
    }

    public void FallRespawn()
    {
        transform.position = lastGroundedPos;
    }

}
