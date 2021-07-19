using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    public GameObject btn;
    public GameObject message;
     public Animator animator;
    public void OpenMail(){
        btn.gameObject.SetActive(false);
        message.gameObject.SetActive(true);
        animator.SetTrigger("MessageIn");
    }
}
