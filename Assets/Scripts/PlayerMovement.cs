using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    private float horizontalMovement;
    private float verticalMovement;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocityX = speed * horizontalMovement;
    }

    public void OnMove(InputAction.CallbackContext context) {
        var movementVec = context.ReadValue<Vector2>();
        horizontalMovement = movementVec.x;
        verticalMovement = movementVec.y;
    }
}
