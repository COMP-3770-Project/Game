using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocketQuest: MonoBehaviour {
    public bool isVisible = false;
    Animator ani;
    public GameObject questBook;
    public void Start() {
        //questBook.SetActive(isVisible);
        ani = GetComponent<Animator>();
        ani.SetBool("isVisible", true);
    }

    public void toggle(){
        ani.SetBool("isVisible", isVisible);
        isVisible = !isVisible;
        //questBook.SetActive(isVisible);

    }
}