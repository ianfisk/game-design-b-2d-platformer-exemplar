using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const float EPSILON = 0.0001f;

    public float speed = 1f;
    public float jumpImpulseForce = 2f;
    public LayerMask groundMask;
    public float groundCastLength = 1f;

    private bool isGrounded;
    private float horizontalMovement;
    private float jumpForce = 0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator spriteAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        var groundRayCast = RaycastUtilities.CastRay(
                new RaycastUtilities.RayData<string>("groundCast", transform.position, Vector2.down, groundCastLength, groundMask));
        isGrounded = groundRayCast;

        if (Math.Abs(horizontalMovement) > EPSILON)
        {
            spriteAnim.SetBool("IsRunning", true);
            spriteRenderer.flipX = horizontalMovement < 0;
        }
        else
        {
            spriteAnim.SetBool("IsRunning", false);
        }
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
        horizontalMovement = movementVec.x; // 1 => Moving right; -1 => Moving left
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && isGrounded)
        {
            jumpForce = jumpImpulseForce;
        }
    }
}
