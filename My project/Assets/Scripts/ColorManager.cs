using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private ColorSwitchable[] allSwitchables;

    void Start()
    {
        // Find all objects with the ColorSwitchable script
        allSwitchables = FindObjectsOfType<ColorSwitchable>();
    }

    public void SwitchAllToColor()
    {
        foreach (var switchable in allSwitchables)
        {
            switchable.SwitchToColor();
        }
    }
}
