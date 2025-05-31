using JetBrains.Annotations;
using UnityEngine;

public class Milk : MonoBehaviour, IItem
{
    [SerializeField] PlayerMovement PlayerMovement;
    public void Collect()
    {

        Destroy(gameObject);
       
    }
    public void isCollected()
    {
        PlayerMovement.milkCollected = true;
    }
   
}
