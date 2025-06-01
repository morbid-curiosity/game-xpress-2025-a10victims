using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 20f;
    public float jumpPower = 40f;

    private Animator animator;

    SpriteRenderer spriteRenderer;

    [SerializeField] Milk milk;
    [SerializeField] Rattle rattle;
    [SerializeField] Crayons crayons;
    public int milkCollected = 0;
    public bool rattleCollected = false;
    public RuntimeAnimatorController secondController;
    public RuntimeAnimatorController thirdController;
    public RuntimeAnimatorController fourthController;


    float horizontalMovement;
    float verticalMovement;
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        if (rb.linearVelocity.x > 0 || rb.linearVelocity.x < 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {

            animator.SetBool("isWalking", false);


        }
        Vector3 scale = transform.localScale;
        if (rb.linearVelocity.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (rb.linearVelocity.x < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        GroundCheck();
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpRemaining > 0 && milkCollected > 0)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                jumpRemaining--;
            }
        }
        if (context.canceled)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            jumpRemaining--;
        }
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpRemaining = milkCollected;
            if (jumpRemaining > 2)
            {
                jumpRemaining = 2;
            }
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    public void milkUpdate()
    {
        milkCollected += 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Milk")
        {
            milkCollected += 1;
            if(milkCollected == 1)
            {
                animator.runtimeAnimatorController = secondController;
            }
            if(milkCollected == 2)
            {
                animator.runtimeAnimatorController = thirdController;
            }
            if (milkCollected == 3)
            {
                animator.runtimeAnimatorController = fourthController;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Rattle")
        {
            rattleCollected = true;
            rattle.destroyRattle();
        }
        if (collision.gameObject.name == "Crayons")
        {
            crayons.DestroyCrayons();
        }
    }
    public int maxJumps = 2;
    int jumpRemaining;

}
