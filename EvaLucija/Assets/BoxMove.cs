using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public void BoxMover()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
