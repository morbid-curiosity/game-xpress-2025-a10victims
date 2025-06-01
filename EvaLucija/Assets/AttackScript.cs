using UnityEngine;
using UnityEngine.InputSystem;

public class AttackScript : MonoBehaviour
{
    public Transform attackPoint;
    public Rigidbody2D rb;
    private Vector2 facingDirection = Vector2.right;
    public float spawnDistance = 3f;
    public float attackCooldown = 1f;
    private float lastAttackTime = 0;
    [SerializeField] PlayerMovement PlayerMovement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.linearVelocity.x > 0)
        {
            facingDirection = Vector2.right;
        }
        else if (rb.linearVelocity.x < 0)
        {
            facingDirection = Vector2.left;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (Time.time < lastAttackTime + attackCooldown || PlayerMovement.rattleCollected != true)
        {
            return;
        }

        Vector2 spawnPosition = (Vector2)transform.position + facingDirection.normalized * spawnDistance + Vector2.down * 2;

        if (facingDirection == Vector2.right)
        {
            Instantiate(attackPoint, spawnPosition, Quaternion.identity * Quaternion.Euler(0, 0, -90));
        }
        else if(facingDirection == Vector2.left)
        {
            Instantiate(attackPoint, spawnPosition, Quaternion.identity * Quaternion.Euler(0, 0, 90));
        }
        lastAttackTime = Time.time;
    }

}
