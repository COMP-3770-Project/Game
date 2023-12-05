using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void MoveToScene(int sceneId)
    {
        Debug.Log(GameManager.stageNumber);
        if(sceneId>=1){
            if(GameManager.stageNumber==1){
                SceneManager.LoadScene(3);
            }
        }
        else{
            SceneManager.LoadScene(sceneId);
        }
        
    }
}
