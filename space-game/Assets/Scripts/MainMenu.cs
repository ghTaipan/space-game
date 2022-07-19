using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelPanel;
    public GameObject TutorialPanel;
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject player;
    public GameObject clickSound;
    public ChooseLevel cl;
    public Tutorial Tut;
    private Animator MManim;
    Vector3 soundPosition;
    public void Start(){
        MManim = GetComponent<Animator>();
        MManim.SetTrigger("MainMenuOn");
        LevelPanel.SetActive(false);
        TutorialPanel.SetActive(false);
        Invoke("destroyFade",1f);
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
    }
    public void newGame(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        player.SetActive(true);
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animator>().SetTrigger("NewGame");
        Invoke("waitNewGame",2f);
    }
    void waitNewGame(){
        SaveSystem.SaveLevel(1);
        SceneManager.LoadScene(1);
    }
    public void Quit(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Application.Quit();
    }
    
    public void Level(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        MManim.SetTrigger("LevelButtonOn");
        Invoke("WaitLevel",0.8f);
    }
    void WaitLevel(){
        LevelPanel.SetActive(true);
        cl.Start();
        cl.playAnim();
    }
    public void Tutorial(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        MManim.SetTrigger("TutorialButtonOn");
        Invoke("waitTutorial",0.6f);
    }
    void waitTutorial(){
        Tut.Start();
        TutorialPanel.SetActive(true); 
        Tut.playAnim();
        
    }
    void destroyFade(){
        Destroy(fadeIn);
    }
    void destroySound(){
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("ClickSound");
        for(int i = 0;i<sounds.Length;i++){
            Destroy(sounds[i]);
        }
    }
}
