using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EscPanel : UIParrent
{
    private Animator EP;
    public GameObject clickSound;
    public GameObject PauseMenuUI;
    public GameObject SoundOn;
    public GameObject SoundOff;
    public Shooting shootingScript;
    private static bool GameIsPaused = false;
    private static bool AnimationIsPlaying;
    private bool activate = false;
    private Vector2 movement;
    private Vector2 movement2;
    private Vector2 movement3;
    private void Start(){
        buttonClicked = false;
        AnimationIsPlaying = false;
        EP = GetComponent<Animator>();
        EP.SetTrigger("LvlStart");
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
        Invoke("waitLoadScreen",1.3f);
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && !AnimationIsPlaying && activate){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    private void waitLoadScreen(){
        activate = true;
    }
    private void Resume(){
        Invoke("activateMovement",0.3f);
        AnimationIsPlaying = true;
        if(SceneManager.GetActiveScene().buildIndex == 1){
            EP.SetTrigger("PMOff");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            EP.SetTrigger("PMOff2");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3){
            EP.SetTrigger("PMOff3");
        }
        else{
            EP.SetTrigger("PMOff4");
        }
        shootingScript.enabled = true;
        GameIsPaused = false;
        Invoke("waitForResume",0.54f);
    }
    public void ResumeUI(){
        Invoke("activateMovement",0.3f);
        buttonClicked = true;
        AnimationIsPlaying = true;
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        if(SceneManager.GetActiveScene().buildIndex == 1){
            EP.SetTrigger("PMOff");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            EP.SetTrigger("PMOff2");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3){
            EP.SetTrigger("PMOff3");
        }
        else{
            EP.SetTrigger("PMOff4");
        }
        
        shootingScript.enabled = true;
        GameIsPaused = false;
        Invoke("waitForResume",0.54f);
    }
    private void activateMovement(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject gameObject in enemies){
            if(gameObject.GetComponent<Enemy2>() != null){
                if(!gameObject.GetComponent<Rigidbody2D>()){
                    gameObject.AddComponent<Rigidbody2D>();
                }
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                if((movement.y != 0 || movement.x != 0)){
                    gameObject.GetComponent<Enemy2>().enabled = true;
                    gameObject.GetComponent<Enemy2>().StartAfterPause(movement);
                    movement = new Vector2();
                }
                else if((movement2.y != 0 || movement2.x != 0)){
                    gameObject.GetComponent<Enemy2>().enabled = true;
                    gameObject.GetComponent<Enemy2>().StartAfterPause(movement2);
                    movement2 = new Vector2();
                }
                else if((movement3.y != 0 || movement3.x != 0)){
                    gameObject.GetComponent<Enemy2>().enabled = true;
                    gameObject.GetComponent<Enemy2>().StartAfterPause(movement3);
                    movement3 = new Vector2();
                }
            }
            else if(gameObject.GetComponent<Enemy3>() != null){
                if(!gameObject.GetComponent<Rigidbody2D>()){
                    gameObject.AddComponent<Rigidbody2D>();
                }
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                    gameObject.GetComponent<Enemy3>().enabled = true;
                    gameObject.GetComponent<Enemy3>().Start();
                
                
            }
        }
       if(FindObjectOfType<WeaponMovement>() != null){
            FindObjectOfType<WeaponMovement>().enabled = true;
        }
    }
    private void waitForResume(){
        AnimationIsPlaying = false;
        PauseMenuUI.SetActive(false);
    }
    void Pause(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject gameObject in enemies){
            if(gameObject.GetComponent<Enemy2>() != null){
                Rigidbody2D rigitbody2D = gameObject.GetComponent<Rigidbody2D>();
                if(movement.y == 0 && movement.x == 0){
                    movement.x = rigitbody2D.velocity.x;
                    movement.y = rigitbody2D.velocity.y; 
                }
                else if(movement2.y == 0 && movement2.x == 0){
                    movement2.x = rigitbody2D.velocity.x;
                    movement2.y = rigitbody2D.velocity.y;
                }
                else if(movement3.y == 0 && movement3.x == 0){
                    movement3.x = rigitbody2D.velocity.x;
                    movement3.y = rigitbody2D.velocity.y;
                }
                Destroy(rigitbody2D);
                gameObject.GetComponent<Enemy2>().enabled = false;
            }
            else if(gameObject.GetComponent<Enemy3>() != null){
                Rigidbody2D rigitbody2D = gameObject.GetComponent<Rigidbody2D>();
                Destroy(rigitbody2D);
                gameObject.GetComponent<Enemy3>().enabled = false;
            }
        }
        if(FindObjectOfType<WeaponMovement>() != null){
            FindObjectOfType<WeaponMovement>().enabled = false;
        }
        buttonClicked = false;
        AnimationIsPlaying = true;
        if(shootingScript){
            shootingScript.enabled = false;
        }
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        if(SceneManager.GetActiveScene().buildIndex == 1){
            EP.SetTrigger("PMOn");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            EP.SetTrigger("PMOn2");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3){
            EP.SetTrigger("PMOn3");
        }
        else{
            EP.SetTrigger("PMOn4");
        }
        Invoke("waitForPause",0.5834f);
    }
    private void waitForPause(){
        AnimationIsPlaying = false;
    }
    public void Retry(){
        EP.SetTrigger("PMToMM");
        buttonClicked = true;
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("waitForRetry",0.67f);
    }
    private void waitForRetry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void AudioSettings(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        EP.SetTrigger("PMAudioOn");
       
    }
    private void AudioToPauseMenu(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        EP.SetTrigger("PMAudioOff");
    }
    public void MainMenu(){
        activate = false;
        buttonClicked = true;
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Destroy(FindObjectOfType<DoNotDestory>().gameObject);
        EP.SetTrigger("PMToMM"); 
        SoundOff.SetActive(false);
        SoundOn.SetActive(false);
        Invoke("waitForMainMenu",0.67f);
    }
    private void waitForMainMenu(){
        SceneManager.LoadScene(0);
    }
    protected override void destroySound(){
        base.destroySound();
    }
    protected override void FixedUpdate(){
        base.FixedUpdate();
    }
    public bool Activate
      {
          get {return activate; }
          set { activate = value;}
      }
    public Animator EPAnim
    {
        get {return EP; }
          set { EP = value;}
    }
}
