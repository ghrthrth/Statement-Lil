using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Attack : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 6f);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 6f);
    }
}
