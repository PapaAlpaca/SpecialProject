using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform ceilingCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask ceilingMask;
    [SerializeField] float speed = 12f;
    private const float g = -9.81f;
    private Vector3 v;
    private float groundDist = 0.4f;
    private float ceilingDist = 0.4f;
    private bool grounded, ceilinged;

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
        ceilinged = Physics.CheckSphere(ceilingCheck.position,ceilingDist,ceilingMask);
        v.y = (grounded&&v.y<0)? -2f: (ceilinged&&v.y>0)? 0f: v.y;
        v.y += 4*g*Time.deltaTime;
        if(grounded&&Input.GetKeyDown(KeyCode.Space)) { v.y += 15f; }
        controller.Move(v*Time.deltaTime);

    }
}
