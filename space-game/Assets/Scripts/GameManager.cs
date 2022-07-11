using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   
    public GameObject completeLevelUI;
    public GameObject failLevelUI;
    public GameObject[] enemyCount;
    public Shooting shooting;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public int mod = 0;
    void Start(){
        int index = SceneManager.GetActiveScene().buildIndex -1;
        mod = index % 4;
        if(index/4 == 0){
            if(mod == 0){
                enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy1.transform.position = new Vector3 (0,2.4f,0);
            }
            else if (mod == 1){
                enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (0,2.4f,0);
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
                enemy1.transform.position = new Vector3 (0,2.4f,0);
            }
            else if (mod == 1){
                enemy1 = Instantiate(Resources.Load("Enemy2")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (0,2.4f,0);
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
                enemy1.transform.position = new Vector3 (0,2.4f,0);
            }
            else if (mod == 1){
                enemy1 = Instantiate(Resources.Load("Enemy3")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (0,2.4f,0);
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
        else{
            if(mod == 0){
                enemy1 = Instantiate(Resources.Load("Enemy4")) as GameObject;
                enemy1.transform.position = new Vector3 (0,2.4f,0);
            }
            else if (mod == 1){
                enemy1 = Instantiate(Resources.Load("Enemy4")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (0,2.4f,0);
            }
            else if (mod == 2){
                enemy1 = Instantiate(Resources.Load("Enemy4")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy4")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (0.7f,2.40f,0);
            }
            else{
                enemy1 = Instantiate(Resources.Load("Enemy4")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy4")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (0.7f,2.40f,0);
                enemy3 = Instantiate(Resources.Load("Enemy4")) as GameObject;
                enemy3.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy3.transform.position = new Vector3 (0,1.2f,0);

            }
        }
    }
    public void LevelCompleted(){
        //shooting.enabled = false;
        completeLevelUI.SetActive(true);
    }
     void FixedUpdate(){
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
       if(enemyCount.Length == 0){
            LevelCompleted();
        }
    }
    public void LevelFailed(){;
        if(enemy1 != null){
            Rigidbody2D rb1 = enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Destroy(rb1);
        }
        if(enemy2 != null){
            Rigidbody2D rb2 = enemy2.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Destroy(rb2);
        }
        if(enemy3 != null){
            Rigidbody2D rb3 = enemy3.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Destroy(rb3);
        }
        StartCoroutine(WaitForLevelFailed(0.5f));
    }
     IEnumerator WaitForLevelFailed(float seconds){
        yield return new WaitForSeconds(seconds);
        if(enemyCount.Length != 0){
            failLevelUI.SetActive(true);
        }
    }
}
