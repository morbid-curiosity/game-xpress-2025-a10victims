using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool a;
    private bool b;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;  
    public float stopDistanceA = 0.1f;
    public float stopDistanceB = 0.1f;
    private bool goToA;

    void Update()
    {

        float distanceA = Vector3.Distance(transform.position, pointA.position);
        float distanceB = Vector3.Distance(transform.position, pointB.position);

        if (distanceA > stopDistanceA && goToA)
        {
            Vector3 direction = (pointA.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else if (distanceA < stopDistanceA && goToA)
        {
            goToA = false;
        }

        if (distanceB > stopDistanceB && goToA == false)
        {
            Vector3 direction = (pointB.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else if (distanceB < stopDistanceA && goToA == false)
        {
            goToA = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "AttackPoint(Clone)")
        {
            Destroy(gameObject);
        }
    }

}
