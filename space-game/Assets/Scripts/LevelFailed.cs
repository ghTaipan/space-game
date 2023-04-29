using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFailed : UIParrent
{
    private Animator LF;
    public GameObject clickSound;
    private void Start(){
        buttonClicked = false;
        LF = GetComponent<Animator>();
        LF.SetTrigger("LFOn");
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
    }
    public void Retry(){
        buttonClicked = true;
        LF.SetTrigger("LFOff");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("waitForRetry",0.84f);
    }
    private void waitForRetry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu(){
        buttonClicked = true;
        LF.SetTrigger("LFOff");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Destroy(FindObjectOfType<DoNotDestory>().gameObject);
        Invoke("waitForMainMenu",0.84f);
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
}
