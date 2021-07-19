using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakeScreen : MonoBehaviour
{
    [SerializeField] int levelIndex;
   private Animator Rotate;
   private void Start() {
        Rotate = GameObject.Find("Rotator").GetComponent<Animator>();   
   }
   public void ToDefault()
    {
        Rotate.SetTrigger("RotatorActive");
        
    }
    public void ToDefaultReserved()
    {
        Rotate.SetTrigger("ReservedRotatorActive");
        
    }
    private void NextScene(){
        SceneManager.LoadScene(levelIndex);
    }
}
