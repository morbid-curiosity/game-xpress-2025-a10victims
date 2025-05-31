using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    // movement
    public float moveSpeed = 5f;
    float horizontalMovement;
    //jumping
    public float jumpPower = 10f;
    //check if on ground
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    public bool milkCollected = false;

    

    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }


    
    public void Jump(InputAction.CallbackContext context)
    {
        
        if (isGrounded() && milkCollected)
        {
            if (context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            else if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }   

    private bool isGrounded()
    {
        if (Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }
        
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheck.position, groundCheckSize);
    }

}
