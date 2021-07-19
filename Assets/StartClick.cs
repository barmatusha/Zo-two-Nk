using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartClick : MonoBehaviour, IPointerClickHandler
{
    private Text thisTxt;
    [SerializeField] Text Continue;
    [SerializeField] Text NewGame;
    private string ContinueTxt = ">Продолжить взлом";
    private string NewGameTxt = ">Начать заново";

    private bool isClicked = false;
    void Start()
    {
       thisTxt = GetComponent<Text>();
    }
    public void OnPointerClick(PointerEventData eventData) 
    {
        if (!isClicked){
        StartCoroutine(output(ContinueTxt, 0.1f, Continue));  
        StartCoroutine(output(NewGameTxt, 0.1f, NewGame)); 
        }
        isClicked = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(isClicked)
        {
       
        }
    }
    IEnumerator output(string str, float delay, Text txt)
    {
        foreach (var sym in str)
        {
            txt.text += sym;
            yield return new WaitForSeconds(delay);  
        }
    }

}
