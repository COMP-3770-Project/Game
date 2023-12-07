using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger : MonoBehaviour
{
    [SerializeField] public Spawner[] spawners;
    [SerializeField] public TextMeshProUGUI timeTracker;
    public float timeRemaining = 30f;
    bool start = false;
    GameObject TimePrompt;
    GameObject GateClose;
    GameObject GateOpen;
    GameObject Queen;
    GameObject QueenHealth;
    void Start(){
        Queen = GameObject.Find("AlienQueen");
        QueenHealth = GameObject.Find("QueenHealth");
        TimePrompt = GameObject.Find("TimeLeft");
        GateClose = GameObject.Find("GateClose");
        GateOpen = GameObject.Find("GateOpen");
        TimePrompt.SetActive(false);
        Queen.SetActive(false);
        QueenHealth.SetActive(false);
    }
    void Update(){
        if(timeRemaining<=0){
            start = false;
            TimePrompt.SetActive(false);
            foreach (Spawner spawner in spawners)
            {
                spawner.gameObject.SetActive(false);
            }
            GateClose.transform.position = new Vector3(GateClose.transform.position.x, 10f, GateClose.transform.position.z);
            GateOpen.SetActive(false);
            Queen.SetActive(true);
            QueenHealth.SetActive(true);
        }
        if(start){
            timeRemaining = timeRemaining - Time.deltaTime;
            timeTracker.text = FloorTo(timeRemaining,1) + " seconds";
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        //Make sure its only on players collider
        TimePrompt.SetActive(true);
        GameManagerSideScroller.Gate.SetActive(true);
            foreach (Spawner spawner in spawners)
            {
                spawner.gameObject.SetActive(true);
            }
            start = true;
            
        
    }
    public static float FloorTo(float value, int place)
        {
            if (place == 0)
            {
                //'if zero no reason going through the math hoops
                return (float)Mathf.Floor(value);
            }
            else
            {
                float p = (float)Mathf.Pow(10, place);
                return (float)Mathf.Floor(value * p) / p;
            }
        }
}
