using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TextDisplaying : MonoBehaviour{
    [SerializeField] Text sttxt;
    [SerializeField] Text entxt;
    private int sVal = 0;
    private string HelloText = ">Hello world";
    private string ContinueText = "Нажмите ЛКМ для продолжения";
    void Start(){
         StartCoroutine(output(HelloText, 0.5f, sttxt));        
    }
    void FixedUpdate(){
        if (sVal == HelloText.Length){
                StartCoroutine(output(ContinueText, 0.09f, entxt));
            }
    }
    IEnumerator output(string str, float delay, Text txt){
        foreach (var sym in str){
            sVal+=1; 
            txt.text += sym;
            yield return new WaitForSeconds(delay);  
        }
    }
}
