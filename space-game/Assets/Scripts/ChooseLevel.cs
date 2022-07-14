using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
public class ChooseLevel : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject[] levelButtons;
    public MainMenu mm;
    public void Start(){
        levelButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        SortArray();
        deactivateButtons();
        MainMenu.SetActive(false);
        activateLevel();
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
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        for(int i = 0 ; i<levelButtons.Length;i++){
            if(levelButtons[i].name.Equals(buttonName)){
                SceneManager.LoadScene(i+1);
            }
        }
    }
    void activateLevel(){
        int Highestlevel = SaveSystem.LoadLevel();
        Debug.Log(Highestlevel);
        for(int i = 0; i< Highestlevel;i++){
            levelButtons[i].SetActive(true);
        }
      
    }
    public void BackToMainMenu(){
        MainMenu.SetActive(true);
        mm.Start();
    }
}