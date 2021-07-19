using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class NewGame : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) 
    {
        SceneManager.LoadScene(2);
    }
}
