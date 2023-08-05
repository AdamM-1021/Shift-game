using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    [Header("Wallrunning")]
    public LayerMask wall;
    public LayerMask ground;
    public float wallRunForce;
    public float maxWallRunTime;
    private float wallRunTimer;

    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallhit;
    private RaycastHit rightWallhit;
    private bool leftWall;
    private bool rightWall;

    [Header("References")]
    public Transform orientation;
    private PlayerMovement pm;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        WallCheck();
        StateMachine();
    }

    private void FixedUpdate()
    {
        if (pm.wallrunning)
        {
            WallRunMovement();
        }

    }

    private void WallCheck()
    {
        rightWall = Physics.Raycast(transform.position, orientation.right, out rightWallhit, wallCheckDistance, wall);
        leftWall = Physics.Raycast(transform.position, -orientation.right, out leftWallhit, wallCheckDistance, wall);
    }

    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, ground);
    }

    private void StateMachine()
    {
        //Inpoots
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        if((leftWall || rightWall) && verticalInput > 0 && AboveGround())
        {
            if(!pm.wallrunning)
            {
                StartWallRun();
            }
        }

        else
        {
            StopWallRun();
        }
    }

    private void WallRunMovement()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);


        Vector3 wallNormal = rightWall ? rightWallhit.normal : leftWallhit.normal;

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if ((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
        {
            wallForward = -wallForward;
        }

        //FUS RO DAH
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);
    }

    private void StartWallRun()
    {
        pm.wallrunning = true;
    }

    private void StopWallRun()
    {
        pm.wallrunning = false;
    }
}
