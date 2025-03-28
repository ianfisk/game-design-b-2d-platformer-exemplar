using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    private float horizontalMovement;
    private float verticalMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context) {
        var movementVec = context.ReadValue<Vector2>();
        horizontalMovement = movementVec.x;
        verticalMovement = movementVec.y;

        Debug.Log($"horizontalMovement = {horizontalMovement}; verticalMovement = {verticalMovement}");
    }
}
