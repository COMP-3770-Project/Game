using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed;


    // Update is called once per frame
    void LateUpdate()
    {

<<<<<<< HEAD
        if (player.position.x <= 6.5 && player.position.x >= -6.25)
            transform.position = Vector3.Lerp(transform.position, player.position + offset, speed);
=======
        if (SceneManager.GetActiveScene().name == "FinalLevel") {
            transform.position = new Vector3(player.position.x, 2f, -6f);
        }
        else{
        if (player.position.x <= 6.5 && player.position.x >= -6.25 && SceneManager.GetActiveScene().name != "FinalLevel") {
            transform.position = Vector3.Lerp(transform.position, player.position + offset, speed);
        }
        else{
            transform.position = Vector3.Lerp(new Vector3(-6.248f,2.6419f,0f), new Vector3(-6.248f,player.position.y+2,0f), speed);
        } 
        }
        
>>>>>>> 536afac8e6405ff2d683f0967ce07ee3512a7cc0
    }
}
