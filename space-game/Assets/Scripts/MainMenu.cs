using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelPanel;
    public GameObject fade;
    public ChooseLevel cl;
    private Animator MManim;
    public void Start(){
        MManim = GetComponent<Animator>();
            MManim.SetTrigger("MainMenuOn");
            LevelPanel.SetActive(false);
            Invoke("destroyFade",0.5f);
    }
    public void newGame(){
        SceneManager.LoadScene(1);
    }
    public void Quit(){
        Application.Quit();
        SaveSystem.SaveLevel(1);
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
        Destroy(fade);
    }
}
