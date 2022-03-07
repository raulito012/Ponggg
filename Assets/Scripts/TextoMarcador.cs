using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextoMarcador : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Animator animator;

    public void Highlight(){
        animator.SetTrigger("Highlight");
    }

    public void SetScore(int value){
        text.text = value.ToString();
        
    }
}
