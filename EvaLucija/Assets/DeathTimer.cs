using UnityEngine;

public class DeathTimer : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.07f);
    }
}
