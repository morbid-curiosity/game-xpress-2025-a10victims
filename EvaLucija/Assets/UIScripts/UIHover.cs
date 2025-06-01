using UnityEngine;
using UnityEngine.EventSystems;

public class UIHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject exitButton;
    public GameObject hoverButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        exitButton.SetActive(false);
        hoverButton.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exitButton.SetActive(true);
        hoverButton.SetActive(false);
    }
}
