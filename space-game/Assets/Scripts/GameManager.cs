using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   
    public GameObject completeLevelUI;
    public GameObject failLevelUI;
    public GameObject[] enemyCount;
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemyWeapon;
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
        if(player.gameObject != null){
            completeLevelUI.SetActive(true);
        }
        completeLevelUI.SetActive(true);
    }
     void FixedUpdate(){
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
       if(enemyCount.Length == 0){
            LevelCompleted();
        }
    }
    public void LevelFailed(){;
        Invoke("WaitForLevelFailed",0.7f);
    }
     void WaitForLevelFailed(){
        if(enemyCount.Length != 0){
            if( player != null){
                KillPlayer();
            }
            else{
                failLevelUI.SetActive(true);
            }
        }
    }
    public void KillPlayer(){
        if(enemy1 != null){
              Destroy(enemy1.GetComponent<Rigidbody2D>());
        }
        if(enemy2 != null){
              Destroy(enemy2.GetComponent<Rigidbody2D>());
        }
        if(enemy3 != null){
            Destroy(enemy3.GetComponent<Rigidbody2D>());
            Vector3 weaponTr = enemy3.GetComponent<Transform>().position;
            Quaternion weaponRt = enemy3.GetComponent<Transform>().rotation;
            weaponTr.y = weaponTr.y + 0.2f;
            weaponRt.z = weaponRt.z + 180;
            Instantiate(enemyWeapon,weaponTr, weaponRt);
        }
        else if(enemy2 != null){
            Vector3 weaponTr = enemy2.GetComponent<Transform>().position;
            Quaternion weaponRt = enemy2.GetComponent<Transform>().rotation;
            weaponTr.y = weaponTr.y + 0.2f;
            weaponRt.z = weaponRt.z + 180;
            Instantiate(enemyWeapon,weaponTr, weaponRt);
        }
        else if (enemy1 != null){
            Vector3 weaponTr = enemy1.GetComponent<Transform>().position;
            Quaternion weaponRt = enemy1.GetComponent<Transform>().rotation;
            weaponTr.y = weaponTr.y + 0.2f;
            weaponRt.z = weaponRt.z + 180;
            Instantiate(enemyWeapon,weaponTr, weaponRt);
        }
    }
}
