using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public ColorManager colorManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // or whatever tag your player uses
        {
            colorManager.SwitchAllToColor();
        }
    }
}
