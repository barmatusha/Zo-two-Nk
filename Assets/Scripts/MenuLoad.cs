using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuLoad : MonoBehaviour
{
    
    [SerializeField] Text StartTxt;
    [SerializeField] Text SettTxt;
    [SerializeField] Text ExTxt;
    Text[] a_Text;
    string[] a_TextArray = {">Начать взлом", ">System Data", ">Отключение"};
    private TextAnimation mTA ;
    private int ButtonId;
    void Start()
    {
        a_Text = new Text[]{StartTxt, SettTxt, ExTxt};
        ButtonId = 0;
        mTA = TextAnimator.CreateAnimation(50);
        mTA.AddTextToQueue(a_TextArray[0]);
        mTA.mEnable = true;
        //  StartCoroutine(output(StartText, 0.1f, StartTxt));
        //  StartCoroutine(output(SettingsText, 0.1f, SettTxt));  
        //  StartCoroutine(output(ExitText, 0.1f, ExTxt));          
    }
    private void Update() {
        if (ButtonId >= 3)
            return;
        a_Text[ButtonId].text = mTA.GetString();
        if (mTA != null && !mTA.mEnable)
        {
            TextAnimator.DestroyAnimation(mTA);
            mTA = null;
            ButtonId++;
            if (ButtonId >= 3)
                return;
            mTA = TextAnimator.CreateAnimation(50);
            mTA.AddTextToQueue(a_TextArray[ButtonId]);
            mTA.mEnable = true;
        }
    }       
    // IEnumerator output(string str, float delay, Text txt)
    // {
    //     foreach (var sym in str)
    //     {
    //         txt.text += sym;
    //         yield return new WaitForSeconds(delay);  
    //     }
    // }
}
