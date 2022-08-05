using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTutorial : UIParrent
{
    public GameObject TutorialPanel;
    private Animator EnemyTutAnim;
    public GameObject next1;
    public GameObject clickSound;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject[] enemies;
    int waitedTimes;
    public void Start(){
        buttonClicked = false;
        waitedTimes = 0;
        EnemyTutAnim = GetComponent<Animator>();
        TutorialPanel.SetActive(false);
        soundPosition.x = 0;
        soundPosition.y = 0;
        next1.SetActive(true);
        soundPosition.z = 0;
    }
    public void instEnemy(){
        enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
        enemy1.transform.position = new Vector3 (0,3.5f,0);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Invoke("killEnemy",3f);
        Invoke("killEnemy",9f);
        Invoke("killEnemy",14f);
        Invoke("killEnemy",20f);
    }
    void killEnemy(){
        foreach(GameObject gameObject in enemies){
            gameObject.GetComponent<Enemy>().Die();
        }
        Invoke("wait",0.2f);
    }
    void wait(){
        if(waitedTimes == 0){
            enemy1 = Instantiate(Resources.Load("Enemy2")) as GameObject;
            enemy1.transform.position = new Vector3 (0,3.5f,0);
        }
        else if(waitedTimes == 1){
            enemy1 = Instantiate(Resources.Load("Enemy3")) as GameObject;
            enemy1.transform.position = new Vector3 (0,3.5f,0);
        }
        else if (waitedTimes == 2){
            enemy1 = Instantiate(Resources.Load("Enemy4")) as GameObject;
            enemy1.transform.position = new Vector3 (0,3.5f,0);
        }
        else if (waitedTimes == 4 ){
            enemy1 = Instantiate(Resources.Load("Enemy2")) as GameObject;
            enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
            enemy1.transform.position = new Vector3 (0,3.5f,0);
        }
        else if (waitedTimes == 5 ){
            enemy1 = Instantiate(Resources.Load("Enemy3")) as GameObject;
            enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
            enemy1.transform.position = new Vector3 (-0.7f,4.6f,0);
            enemy2 = Instantiate(Resources.Load("Enemy3")) as GameObject;
            enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
            enemy2.transform.position = new Vector3 (0.7f,4.6f,0);
        }
        else if(waitedTimes == 6){
            enemy1 = Instantiate(Resources.Load("Enemy4")) as GameObject;
            enemy1.transform.localScale = new Vector3(0.66f,0.66f,1);
            enemy1.transform.position = new Vector3 (-0.7f,4.6f,0);
            enemy2 = Instantiate(Resources.Load("Enemy4")) as GameObject;
            enemy2.transform.localScale = new Vector3(0.66f,0.66f,1);
            enemy2.transform.position = new Vector3 (0.7f,4.6f,0);
            enemy3 = Instantiate(Resources.Load("Enemy4")) as GameObject;
            enemy3.transform.localScale = new Vector3(0.66f,0.66f,1);
            enemy3.transform.position = new Vector3 (0,3.4f,0);
        }
        waitedTimes++;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    public void EnemyTut1(){
        enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
        enemy1.transform.position = new Vector3 (0,3.5f,0);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyTutAnim.SetTrigger("ET1On");
        next1.SetActive(false);
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("killEnemy",6f);
        Invoke("killEnemy",12f);
        Invoke("killEnemy",17f);
        Invoke("killEnemy",22f);
    }
    public void BackToTutorialScreen(){
        buttonClicked = true;
        EnemyTutAnim.SetTrigger("ETOutro");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("WaitTTScreen",0.84f);
    }
    void WaitTTScreen(){ 
        TutorialPanel.SetActive(true);
        TutorialPanel.GetComponent<Tutorial>().Start();
        TutorialPanel.GetComponent<Animator>().SetTrigger("Return");
    }
    public override void destroySound(){
        GameObject[] clickSounds = GameObject.FindGameObjectsWithTag("DeathSound");
        GameObject[] deathSounds = GameObject.FindGameObjectsWithTag("ClickSound");
        for(int i = 0;i<deathSounds.Length;i++){
            Destroy(deathSounds[i]);
        }
        for(int i = 0;i<clickSounds.Length;i++){
            Destroy(clickSounds[i]);
        }
    }
    public override void FixedUpdate(){
        base.FixedUpdate();
    }
}
