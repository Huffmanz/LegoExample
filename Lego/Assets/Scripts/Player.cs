using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 moveDirection = Vector3.zero;

    public float gravity=20.0f;
    public float jumpForce = 10.0f;
    public float speed = 50.0f;
    public float turnSpeed = 50.0f;

    public GameObject runFace;
    public GameObject idleFace;
    public GameObject jumpFace;



    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded && Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("AnimPar", 1);
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            runFace.SetActive(true);
            idleFace.SetActive(false);
            jumpFace.SetActive(false);

        }
        else if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * 0;
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            anim.SetInteger("AnimPar", 0);
            runFace.SetActive(false);
            idleFace.SetActive(true);
            jumpFace.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            anim.SetInteger("AnimPar", 2);
            moveDirection.y = jumpForce;
            runFace.SetActive(false);
            idleFace.SetActive(false);
            jumpFace.SetActive(true);
        }

        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}
