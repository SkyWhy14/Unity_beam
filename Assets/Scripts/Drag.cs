using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    SFX_Script script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script = FindFirstObjectByType<SFX_Script>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Implementing IPointerDownHandler
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Izdarīts klikšķis uz velkamā objekta");
        script.PlaySFX(1);
    }

    // Implementing IBeginDragHandler
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Sākts vilkšanas process");
    }

    // Implementing IDragHandler
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Objekts tiek vilkts");
        Vector2 mousePosition = eventData.position;
        mousePosition.x = Mathf.Clamp(mousePosition.x,
            0 + rectTransform.rect.width / 2, Screen.width - rectTransform.rect.width / 2);

        mousePosition.y = Mathf.Clamp(mousePosition.y,
           0 + rectTransform.rect.height / 2, Screen.height - rectTransform.rect.height / 2);

        rectTransform.position = mousePosition;
    }

    // Implementing IEndDragHandler
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Vilkšanas process pabeigts");
    }
}