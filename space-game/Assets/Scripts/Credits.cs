using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public int switchToMenu = 0;
    public GameObject fade;

    public void Quit(){
        Application.Quit();
    }
    public void MainMenu(){
        switchToMenu = 1;
        fade.SetActive(true);
        Invoke("waitForMenu",0.6f);
    }
    void waitForMenu(){
        SceneManager.LoadScene(0);
    }
}
