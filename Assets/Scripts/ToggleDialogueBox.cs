using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ToggleDialogueBox : MonoBehaviour
{
    public bool isVisible = false;
    //Animator ani;
    public TextMeshProUGUI text;




    public void Start()
    {
        gameObject.SetActive(isVisible);

    }



    public void SetDialogueText(string str)
    {
        text.SetText(str);
    }

    public void OnButtonClick()
    {
        isVisible = false;
        //ani.SetBool("isVisible", isVisible);
        gameObject.SetActive(false);
    }

    public void toggle()
    {
        //ani.SetBool("isVisible", isVisible);
        isVisible = !isVisible;
        gameObject.SetActive(isVisible);

    }
}
