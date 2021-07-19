using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private int SceneIndex;
    public void FadeToLevelFun ()
    {
        animator.SetTrigger("NextLevelTrigger");
    }

    public void OnFadeCompleteFun()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
