using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GrayChange : MonoBehaviour
{
    private UniversalAdditionalCameraData camData;
    public void changeMask()
    {
        Camera mainCam = Camera.main;
        camData = mainCam.GetUniversalAdditionalCameraData();
        camData.volumeLayerMask = LayerMask.GetMask("Default");
    }
}
