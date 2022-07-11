using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFailed : MonoBehaviour
{
    private Animator LF;
    void Start(){
        LF = GetComponent<Animator>();
        LF.SetTrigger("LFOn");
    }
    public void Retry(){
        LF.SetTrigger("LFOff");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu(){
        LF.SetTrigger("LFOff");
        SceneManager.LoadScene(0);
    }
}
