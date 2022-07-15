using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelPanel;
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject player;
    public ChooseLevel cl;
    private Animator MManim;
    public void Start(){
        MManim = GetComponent<Animator>();
            MManim.SetTrigger("MainMenuOn");
            LevelPanel.SetActive(false);
            Invoke("destroyFade",1f);
    }
    public void newGame(){
        player.SetActive(true);
        fadeOut.SetActive(true);
        Invoke("waitNewGame",2f);
    }
    void waitNewGame(){
        SaveSystem.SaveLevel(1);
        SceneManager.LoadScene(1);
    }
    public void Quit(){
        Application.Quit();
    }
    public void Level(){
        MManim.SetTrigger("LevelButtonOn");
        Invoke("WaitLevel",0.8f);
    }
    void WaitLevel(){
        LevelPanel.SetActive(true);
        cl.Start();
    }
    void destroyFade(){
        Destroy(fadeIn);
    }
}
