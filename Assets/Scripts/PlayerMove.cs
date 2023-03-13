using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Elevator elevator;
    [SerializeField] float speed = 12f;
    private const float g = -9.81f;
    private Vector3 v;
    private float groundDist = 0.4f;
    private bool grounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        controller.Move((transform.right*x + transform.forward*z)*speed*Time.deltaTime);
        grounded = Physics.CheckSphere(groundCheck.position,groundDist,groundMask);
        if((grounded||elevator.isMoving())&&v.y<0) { v.y = -2f; }
        v.y += g*Time.deltaTime;
        if((grounded||elevator.isMoving())&&Input.GetKeyDown(KeyCode.Space)) { v.y += 10f; }
        controller.Move(v*Time.deltaTime);

    }

    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            elevator.reset();
            transform.position = new Vector3(0.0f, 2.5f, 0.0f);
        }
    }
}
