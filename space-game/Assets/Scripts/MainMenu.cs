using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : UIParrent
{
    public GameObject LevelPanel;
    public GameObject TutorialPanel;
    public GameObject AudioPanel;
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject player;
    public GameObject clickSound;
    public GameObject ContinueButton;
    private Animator MManim;
    public void Start(){
        SaveSystem.LoadLevel();
        MManim = GetComponent<Animator>();
        if(TutorialPanel || LevelPanel){
            playAnimMM();
        }
        else{
            Invoke("playAnimMM",0.3f);
        }
        buttonClicked = false;
        //MManim = GetComponent<Animator>();
        //MManim.SetTrigger("MainMenuOn");
        LevelPanel.SetActive(false);
        TutorialPanel.SetActive(false);
        Invoke("destroyFade",1f);
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
    }
    private void playAnimMM(){
        if(SaveSystem.LoadLevel() == 0){
            MManim.SetTrigger("MainMenuOn");
        }
        else{
             MManim.SetTrigger("MainMenuOn2");
        }
    }
    public void newGame(){
        buttonClicked = true;
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        player.SetActive(true);
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animator>().SetTrigger("NewGame");
        Invoke("waitNewGame",2f);
    }
    private void waitNewGame(){
        FindObjectOfType<DoNotDestory>().LevelNumber = 0;
        SaveSystem.SaveLevel(1);
        SceneManager.LoadScene(1);
    }
    public void Continue(){
        buttonClicked = true;
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        player.SetActive(true);
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animator>().SetTrigger("NewGame");
        Invoke("waitContinue",2f);
    }
    private void waitContinue(){
        FindObjectOfType<DoNotDestory>().LevelNumber = SaveSystem.LoadLevel()-1;
        if(SaveSystem.LoadLevel() == 4 || SaveSystem.LoadLevel()  == 8 || SaveSystem.LoadLevel() == 12 || SaveSystem.LoadLevel() == 16  ){
            SceneManager.LoadScene((SaveSystem.LoadLevel()/4));
        }
        else{
            SceneManager.LoadScene((SaveSystem.LoadLevel()/4 + 1));
        }
    }
    public void Quit(){
        //SaveSystem.SaveLevel(0); To test if continue button does not appear when the game is played for the first time.
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Application.Quit();
    }
    
    public void Level(){
        buttonClicked = true;
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        LTAnim();
        Invoke("WaitLevel",0.67f);
    }
    private void WaitLevel(){
        LevelPanel.SetActive(true);
        LevelPanel.GetComponent<ChooseLevel>().Start();
        LevelPanel.GetComponent<ChooseLevel>().playAnim();
    }
    public void Tutorial(){
        buttonClicked = true;
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        LTAnim();
        Invoke("waitTutorial",0.67f);
    }
    private void LTAnim(){
        if(SaveSystem.LoadLevel() <= 0 ){
            MManim.SetTrigger("LTButtonOn2");
        }
        else{
             MManim.SetTrigger("LTButtonOn");
        }
    }
    private void waitTutorial(){
        TutorialPanel.SetActive(true); 
        TutorialPanel.GetComponent<Tutorial>().Start();
        TutorialPanel.GetComponent<Tutorial>().playAnim();
        
    }
    public void Audio(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        AudioPanel.SetActive(true);
        Invoke("destroySound",0.3f);
        AudioPanel.GetComponent<Animator>().SetTrigger("APOn");
    }
    public void AudioOff(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        AudioPanel.GetComponent<Animator>().SetTrigger("APOff");
        Invoke("waitAudioOff",0.5f);
    }
    private void waitAudioOff(){
         AudioPanel.SetActive(false);
    }
    void destroyFade(){
        Destroy(fadeIn);
    }
    protected override void destroySound(){
        base.destroySound();
    }
    protected override void FixedUpdate(){
        base.FixedUpdate();
    }
}
