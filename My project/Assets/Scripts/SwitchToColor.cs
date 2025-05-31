using UnityEngine;

public class ColorSwitchable : MonoBehaviour
{
    public Sprite blackAndWhiteSprite;
    public Sprite colorSprite;

    private SpriteRenderer spriteRenderer;
    private bool isColor = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = blackAndWhiteSprite;  // start BW
    }

    public void SwitchToColor()
    {
        if (!isColor)
        {
            spriteRenderer.sprite = colorSprite;
            isColor = true;
        }
    }
}
