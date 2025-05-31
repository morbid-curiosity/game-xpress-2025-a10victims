using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 6f;
    float horizontalMovement;

    public float jumpPower = 8f;

    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x; 
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        else if(context.canceled)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
}
