using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class BtnShop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 6f);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 6f);
        SceneManager.LoadScene("Shop");
    }
}
