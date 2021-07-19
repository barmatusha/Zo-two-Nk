using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    quize mquiz;
    TerminalStringManager mTSM;
    [SerializeField] int currentDiffuculte;
    [SerializeField] Text Questtxt;
    [SerializeField] Text AnswerVariant;
    [SerializeField] Text Terminaltxt;
    [SerializeField] Text TimerTxt;
    private Animator Rotate;
    question currentQuestion;
    int currentProgress;
    int countOfCurrentQue;  
    double timeLeft = 0;
    double totalTime = 0;
    int totalChars = 0;

    TextAnimation mAnimText;
    string mTerminalAnimatedText ="";
    private void Start() {
        
        Rotate = GameObject.Find("Rotator").GetComponent<Animator>();
        currentProgress = 0;
        mTSM = new TerminalStringManager();
        mquiz = new quize();
        countOfCurrentQue = mquiz.CountOfQue(currentDiffuculte);//3
        totalTime = ((1*currentDiffuculte) + (currentDiffuculte/2))*mquiz.CountOfQue(currentDiffuculte); 
        timeLeft = totalTime;
        genQuest();
        totalChars = TimerTxt.text.Length-2;

        mAnimText = TextAnimator.CreateAnimation(7);
    }
    void genQuest()
    {
        currentQuestion = mquiz.randQuest(currentDiffuculte);
        if (currentQuestion == null)
        {
            //SceneManager.LoadScene("WinScene");
            return;
        }
        Questtxt.text = currentQuestion.m_Qtitle;
        AnswerVariant.text = currentQuestion.m_Qanswer;
    }
    void TermimalDisplay(){
        int countOfTerminalLines = mTSM.GetCountOfLines(currentDiffuculte);
        int CountLinesPerQue =  countOfTerminalLines/countOfCurrentQue;
        for (int i = ((currentProgress-1)*CountLinesPerQue); i<CountLinesPerQue*currentProgress; i++){
            mAnimText.AddTextToQueue(mTSM.GetTerminalString(currentDiffuculte, i).TerminalLine + "\n");
            mAnimText.mEnable = true; 
        }
    }
    private void NextScene(){
        Debug.Log("Scene to load");
        SceneManager.LoadScene(6);
    }
    private void FixedUpdate() {
        if (timeLeft <= 0 && currentDiffuculte != 1){
            SceneManager.LoadScene("LoseScene");
            return;
        }
        if (currentQuestion == null){
            Rotate.SetTrigger("QueEnded");
        }
        if (currentQuestion == null && !mAnimText.mEnable){
            Rotate.SetTrigger("FadeController");
            return;
        }
        Terminaltxt.text = mAnimText.GetString();
        if (timeLeft > totalTime)
            totalTime = timeLeft;
        timeLeft-=Time.fixedDeltaTime*currentDiffuculte;
        int countChertochek = (int)(((double)totalChars / totalTime) * timeLeft);
        TimerTxt.text = "[";
        for(int i = 0; i < totalChars; i++) {
            TimerTxt.text += (i < countChertochek) ? "|" : " ";
        }
        TimerTxt.text += "]";
    } 
    void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            
            if (currentQuestion.isCorrect){
                Rotate.SetTrigger("RotatorActive");
                currentProgress++;
                timeLeft += (1*currentDiffuculte) + (currentDiffuculte/2);
                TermimalDisplay();
                genQuest();
            }
            else{
               SceneManager.LoadScene("LoseScene");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1)){
           if (!currentQuestion.isCorrect){
                Rotate.SetTrigger("ReservedRotatorActive");
                currentProgress++;
                timeLeft += (1*currentDiffuculte) + (currentDiffuculte/2);
                TermimalDisplay();
                genQuest();
            }
            else{
               SceneManager.LoadScene("LoseScene");
            }
        }
    }

}
