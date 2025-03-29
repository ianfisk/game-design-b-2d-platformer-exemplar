using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public LayerMask groundMask;
    public float groundCastLength = 1f;

    private bool isGrounded;
    private float horizontalMovement;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var groundRayCast = RaycastUtilities.CastRay(
                new RaycastUtilities.RayData<string>("groundCast", transform.position, Vector2.down, groundCastLength, groundMask));
        if (groundRayCast) {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocityX = speed * horizontalMovement;
    }

    public void OnMove(InputAction.CallbackContext context) {
        var movementVec = context.ReadValue<Vector2>();
        horizontalMovement = movementVec.x;
    }

    public void OnJump(InputAction.CallbackContext context) {
    }
}
