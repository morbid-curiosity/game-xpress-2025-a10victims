using UnityEngine;

public class DestroyMilk : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        { 
            Destroy(gameObject);
        }
    }
}
