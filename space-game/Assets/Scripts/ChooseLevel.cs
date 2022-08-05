using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
public class ChooseLevel : UIParrent
{
    public GameObject MainMenu;
    public GameObject[] levelButtons;
    public GameObject fadeOut;
    public GameObject clickSound;
    private Animator levelAnim;
    string buttonName;
    public void Start(){
        buttonClicked = false;
        levelAnim = GetComponent<Animator>();
        levelButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        SortArray();
        deactivateButtons();
        MainMenu.SetActive(false);
        activateLevel();
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
    }
    public void playAnim(){
        levelAnim.SetTrigger("LevelPanelOn");
    }
    void SortArray(){
        GameObject temp;
        for(int i = 0 ; i< levelButtons.Length-1; i++){
            if(string.Compare(levelButtons[i].name,levelButtons[i+1].name) > 0 ){
                temp = levelButtons[i+1];
                levelButtons[i+1] = levelButtons[i];
                levelButtons[i] = temp;
                SortArray();
            }
        }
    }
    void deactivateButtons(){
        for(int i = 0 ; i<levelButtons.Length;i++){
            levelButtons[i].SetActive(false);
        }
    }
    public void activateScene(){
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        buttonClicked = true;
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animator>().SetTrigger("Level");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("waitActivateScene",0.7f);
    }
    void waitActivateScene(){
        for(int i = 0 ; i<levelButtons.Length;i++){
            if(levelButtons[i].name.Equals(buttonName)){
                FindObjectOfType<DoNotDestory>().levelNumber = i;
                SceneManager.LoadScene((i/4)+1);
            }
        }
    }
    void activateLevel(){
        int Highestlevel = SaveSystem.LoadLevel();
        if(Highestlevel == 0){
            Highestlevel = 1;
        }
        for(int i = 0; i< Highestlevel;i++){
            levelButtons[i].SetActive(true);
        }
      
    }
    public void BackToMainMenu(){
        buttonClicked = true;
        levelAnim.SetTrigger("MMOn");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("waitMM",0.7f);
    }
    void waitMM(){
        MainMenu.SetActive(true);
        MainMenu.GetComponent<MainMenu>().Start();
    }
    public override void destroySound(){
        base.destroySound();
    }
    public override void FixedUpdate(){
        base.FixedUpdate();
    }
}
