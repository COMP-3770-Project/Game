using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void MoveToScene(int sceneId)
    {
        if(sceneId>=1){
            if(GameManager.stageNumber==2){
                SceneManager.LoadScene(3);
            }
            if(GameManager.stageNumber==3){
                SceneManager.LoadScene(4);
            }
            if(GameManager.stageNumber==4){
                SceneManager.LoadScene(5);
            }
        }
        else{
            SceneManager.LoadScene(sceneId);
        }
        
    }
}
