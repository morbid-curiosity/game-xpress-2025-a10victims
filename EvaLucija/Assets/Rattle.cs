using UnityEngine;

public class Rattle : MonoBehaviour
{
    [SerializeField] BoxMove BoxMove;
    public void destroyRattle()
    {
        BoxMove.BoxMover();
        Destroy(gameObject);
    }

}
