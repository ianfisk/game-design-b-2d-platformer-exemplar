using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpImpulseForce = 2f;
    public LayerMask groundMask;
    public float groundCastLength = 1f;

    private bool isGrounded;
    private float horizontalMovement;
    private float jumpForce = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var groundRayCast = RaycastUtilities.CastRay(
                new RaycastUtilities.RayData<string>("groundCast", transform.position, Vector2.down, groundCastLength, groundMask));
        isGrounded = groundRayCast;
    }

    void FixedUpdate()
    {
        rb.velocityX = speed * horizontalMovement;

        // We want to add force to rigid bodies in FixedUpdate because Unity does all physics
        // calculations and updates immediately after FixedUpdate.
        if (jumpForce > 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpForce = 0f;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var movementVec = context.ReadValue<Vector2>();
        horizontalMovement = movementVec.x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && isGrounded)
        {
            jumpForce = jumpImpulseForce;
        }
    }
}
