using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HelpMessageManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Text currentText;
    [SerializeField] public Text descriptionText;
    public bool isMouseOver = false;
    [SerializeField] private string message;
    
    public void OnPointerEnter(PointerEventData eventData){
        StartCoroutine(output(message, 0.1f, descriptionText));
    }
    public void OnPointerExit(PointerEventData eventData){
        this.descriptionText.text = "";
        StopAllCoroutines();
    }
      private void Update() {
        if(isMouseOver){
            StartCoroutine(output(message, 0.5f, descriptionText));   
        }
        else{
            StopCoroutine("output");
        }
    }
    private void OnMouseEnter() {
        isMouseOver = true;      
    }
    private void OnMouseExit() {
        isMouseOver = false;
    }
    private void OnMouseOver() {
        StartCoroutine(output(message, 0.5f, descriptionText));  
    }

IEnumerator output(string str, float delay, Text txt){
        foreach (var sym in str){
            txt.text += sym;
            yield return new WaitForSeconds(delay);  
        }
    }

}
