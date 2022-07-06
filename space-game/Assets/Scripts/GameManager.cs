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
        int mod = SceneManager.GetActiveScene().buildIndex % 4;
        Debug.Log(mod);
        if(SceneManager.GetActiveScene().buildIndex/4 <= 1){
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
                enemy1.transform.position = new Vector3 (0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (-0.7f,2.40f,0);
            }
            else{
                enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy1.transform.position = new Vector3 (0.7f,2.40f,0);
                enemy2 = Instantiate(Resources.Load("Enemy1")) as GameObject;
                enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
                enemy2.transform.position = new Vector3 (-0.7f,2.40f,0);
                enemy3 = Instantiate(Resources.Load("Enemy1")) as GameObject;
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
    }
    public void gameOver(){;
        StartCoroutine(WaitForGameOver(0.5f));
    }
     IEnumerator WaitForGameOver(float seconds){
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
