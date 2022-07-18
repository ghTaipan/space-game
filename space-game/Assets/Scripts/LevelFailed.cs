using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFailed : MonoBehaviour
{
    private Animator LF;
    public GameObject clickSound;
    Vector3 soundPosition;
    void Start(){
        LF = GetComponent<Animator>();
        LF.SetTrigger("LFOn");
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
    }
    public void Retry(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("waitForRetry",0.1f);
    }
    void waitForRetry(){
        LF.SetTrigger("LFOff");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Destroy(FindObjectOfType<DoNotDestory>().gameObject);
        Invoke("waitForMainMenu",0.1f);
    }
    void waitForMainMenu(){
        LF.SetTrigger("LFOff");
        SceneManager.LoadScene(0);
    }
    void destroySound(){
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("ClickSound");
        for(int i = 0;i<sounds.Length;i++){
            Destroy(sounds[i]);
        }
    }
}
