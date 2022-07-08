using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public GameObject failLevelUI;
    public GameObject[] enemyCount;
    public WeaponMovement movement;
    public Shooting shooting;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    void Start(){
        int index = SceneManager.GetActiveScene().buildIndex;
        int mod = index % 4;
        if(index/4 == 0){
            if(mod == 0){
                enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
            }
            else if (mod == 1){
                enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
            }
            else if (mod == 2){
                enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (0.7f,2.40f,0);
            }
            else{
                enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (0.7f,2.40f,0);
                enemy3 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy3.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy3.transform.position = new Vector3 (0,1.2f,0);

            }
        }
        else if( index/4 == 1){
            if(mod == 0){
                enemy1 = Instantiate(Resources.Load("Enemy2")) as GameObject;
            }
            else if (mod == 1){
                enemy1 = Instantiate(Resources.Load("Enemy2")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
            }
            else if (mod == 2){
                enemy1 = Instantiate(Resources.Load("Enemy2")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy2")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (0.7f,2.40f,0);
            }
            else{
                enemy1 = Instantiate(Resources.Load("Enemy2")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy2")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (0.7f,2.40f,0);
                enemy3 = Instantiate(Resources.Load("Enemy2")) as GameObject;
                enemy3.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy3.transform.position = new Vector3 (0,1.2f,0);

            }
        }
        else if( index/4 == 2){
             if(mod == 0){
                enemy1 = Instantiate(Resources.Load("Enemy3")) as GameObject;
            }
            else if (mod == 1){
                enemy1 = Instantiate(Resources.Load("Enemy3")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
            }
            else if (mod == 2){
                enemy1 = Instantiate(Resources.Load("Enemy3")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy3")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (0.7f,2.40f,0);
            }
            else{
                enemy1 = Instantiate(Resources.Load("Enemy3")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy3")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (0.7f,2.40f,0);
                enemy3 = Instantiate(Resources.Load("Enemy3")) as GameObject;
                enemy3.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy3.transform.position = new Vector3 (0,1.2f,0);

            }
        }
    }
    public void LevelCompleted(){
        shooting.enabled = false;
        completeLevelUI.SetActive(true);
    }
     void FixedUpdate(){
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
       if(enemyCount.Length == 0){
            movement.enabled = false;
            LevelCompleted();
        }
        /*if(enemy1 != null && enemy2 != null){
            Rigidbody2D rb = enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Rigidbody2D rb2 = enemy2.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            if (rb.velocity != rb2.velocity){
                    Debug.Log(switchSide);
                    if(switchSide == 0){
                        rb2.velocity = -rb2.velocity;
                        switchSide = 1;     
                    }
                    else{
                        rb.velocity = -rb.velocity;
                        switchSide = 0;
                    }
            }
       }
       */
    }
    public void LevelFailed(){;
        StartCoroutine(WaitForLevelFailed(0.5f));
    }
     IEnumerator WaitForLevelFailed(float seconds){
        yield return new WaitForSeconds(seconds);
        if(enemyCount.Length != 0){
            failLevelUI.SetActive(true);
            Invoke("Restart",restartDelay);
        }
    }
    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
