using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocketQuest: MonoBehaviour {
    bool isVisible = false;
    Animator ani;
    public GameObject questBook;
    public void Awake(){
        ani = GetComponent<Animator>();
        ani.SetBool("isVisible", true);
    }
    // public void Start() {
    //     //questBook.SetActive(isVisible);
    //     ani = GetComponent<Animator>();
    //     ani.SetBool("isVisible", true);
    // }

    public void toggle(){
        ani.SetBool("isVisible", isVisible);
        isVisible = !isVisible;
        //questBook.SetActive(isVisible);

    }
}