using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Acceleration = 40f;
    public float JumpForce = 200f;
    public float ExtraGravityForce = 40f;

    private Rigidbody rb;
    private Camera camera;
    private Collider collider;
    
    private bool shouldJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            shouldJump = true;
    }

    private bool IsGrounded()
    {
        var expectedDistanceToGround = collider.bounds.extents.y * 1.1f;
        return Physics.Raycast(transform.position, -Vector3.up, expectedDistanceToGround + 0.1f);
    }

    void FixedUpdate()
     {
            var cameraForward = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
            var cameraRight = Vector3.ProjectOnPlane(camera.transform.right, Vector3.up);

            rb.AddForce(Input.GetAxisRaw("Vertical") * cameraForward * Acceleration, ForceMode.Acceleration);
            rb.AddForce(Input.GetAxisRaw("Horizontal") * cameraRight *  Acceleration, ForceMode.Acceleration);

            if (shouldJump)
            {
                rb.AddForce(JumpForce * Vector3.up, ForceMode.VelocityChange);
                shouldJump = false;
            }

        // Extra gravity
        rb.AddForce(ExtraGravityForce * Vector3.down, ForceMode.Acceleration);
    }
}
