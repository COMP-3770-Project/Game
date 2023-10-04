using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocketQuest: MonoBehaviour {
    public bool isVisible = false;
    public GameObject questBook;
    public void Start() {
        questBook.SetActive(isVisible);
    }

    public void toggle(){
        isVisible = !isVisible;
        questBook.SetActive(isVisible);

    }
}