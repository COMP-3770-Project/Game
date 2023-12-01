using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ToggleDialogueBox : MonoBehaviour
{
    public bool isVisible = false;
    Animator ani;
    public TextMeshProUGUI text;
    //public void Awake()
    //{
    //    ani = GetComponent<Animator>();
    //    ani.SetBool("isVisible", true);
    //}


    // public void Start() {
    //     //questBook.SetActive(isVisible);
    //     ani = GetComponent<Animator>();
    //     ani.SetBool("isVisible", true);
    // }

    //public void toggle()
    //{
    //    ani.SetBool("isVisible", isVisible);
    //    isVisible = !isVisible;
    //    //questBook.SetActive(isVisible);

    //}

    public void SetDialogueText(string str)
    {
        text.SetText(str);
    }

    public void OnButtonClick()
    {
        gameObject.SetActive(false);
    }
}