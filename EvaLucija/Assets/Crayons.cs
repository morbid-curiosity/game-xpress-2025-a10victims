using UnityEngine;

public class Crayons : MonoBehaviour
{
    [SerializeField] SaturationChange saturationChange;
    public void DestroyCrayons()
    {
       // saturationChange.ChangeSaturation();
        Destroy(gameObject);
    }
}
