using UnityEngine;

public class Milk : MonoBehaviour
{
    [SerializeField] GrayChange GrayChange;
    public void destroyMilk()
    {
        GrayChange.changeMask();
        Destroy(gameObject);
    }
}
