using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QueenShooter : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Queen;
    public GameObject Player;
    public Transform bulletPOS;

    public AudioSource firingEffect;
    public int queenHealth = 100;
    public Image queenHealthBar;
    private float timer;
    private float timer2;
    public Animator ani;
    public SpriteRenderer r;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Queen.transform.position.x>=Player.transform.position.x){
            r.flipX = false; 
        }
        else{
            r.flipX = true;
        }
        if(queenHealth>=0){
            queenHealthBar.fillAmount = (float)queenHealth/(float)100;
            timer += Time.deltaTime;
            timer2 += Time.deltaTime;
            if(timer>=2){
                timer = 0;
                firingEffect.Play();
                shoot();
            }
            if(timer2>=5){
                timer2 = 0;
                moveToOtherSide();
            }
        }
        else{
            Queen.transform.position = new Vector3(Queen.transform.position.x, Queen.transform.position.y, -100f);
            SceneManager.LoadScene("FinalCutscene");
        }
        
    }

    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.layer==9){
            queenHealth -= 5;
            Destroy(c.gameObject);
        }
    }
    void shoot(){
        Instantiate(bullet, bulletPOS.position, Quaternion.identity);
    }
    void moveToOtherSide(){
        float num = Random.Range(0, 3);
        switch(num){
            case 0:
                Queen.transform.position = new Vector3(66.5f, 3.5f, Queen.transform.position.z);
                break;
            case 1:
                Queen.transform.position = new Vector3(66.5f, 0.35f, Queen.transform.position.z);
                break;
            case 2:
                Queen.transform.position = new Vector3(75.5f, 3.5f, Queen.transform.position.z);
                break;
            case 3:
                Queen.transform.position = new Vector3(75.5f, 0.35f, Queen.transform.position.z);
                break;
        }
    }
}
