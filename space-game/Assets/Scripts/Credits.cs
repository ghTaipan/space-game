using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : UIParrent
{
    private int switchToMenu = 0;
    public GameObject fade;
    public GameObject clickSound;

    public void Quit(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Application.Quit();
    }
    public void MainMenu(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        switchToMenu = 1;
        fade.SetActive(true);
        Invoke("waitForMenu",0.6f);
    }
    private void waitForMenu(){
        SceneManager.LoadScene(0);
    }
    protected override void destroySound(){
        base.destroySound();
    }
    protected override void FixedUpdate(){
        base.FixedUpdate();
    }
    public int SwitchToMenu
      {
          get {return switchToMenu; }
          set { switchToMenu = value;}
      }
}
