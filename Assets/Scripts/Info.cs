using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class Info : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) 
    {
        SceneManager.LoadScene(11);
    }
}
