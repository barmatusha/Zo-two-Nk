using UnityEngine.EventSystems;
using UnityEngine;

public class Exit : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) 
    {
         Application.Quit();
    }
}
