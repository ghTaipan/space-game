using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject ShootingTutorialPanel;
    public GameObject EnemyTutorialPanel;
    public GameObject MainMenu;
    public GameObject clickSound;
    public MainMenu mm;
    private Animator TutAnim;
    public ShootingTutorial st;
    Vector3 soundPosition;
  
    public void Start(){
        MainMenu.SetActive(false);
        ShootingTutorialPanel.SetActive(false);
        TutAnim = GetComponent<Animator>();
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
    }
    public void playAnim(){
        TutAnim.SetTrigger("Start");
    }
    public void ShootingTutorial(){
        TutAnim.SetTrigger("Button");
        Invoke("waitForST",1f);
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
    }
    void waitForST(){
        ShootingTutorialPanel.SetActive(true);
        st.Start();
        st.WeaponMethods();
        ShootingTutorialPanel.GetComponent<Animator>().SetTrigger("STIntro");
        ShootingTutorialPanel.GetComponent<ShootingTutorial>().weapon.GetComponent<Animator>().SetTrigger("WeaponTutOn");
    }
    public void EnemyTutorial(){
        TutAnim.SetTrigger("Button");
        Invoke("waitForET",1f);
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
    }
    void waitForET(){
        EnemyTutorialPanel.SetActive(true);
    }
    public void BackToMainMenu(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        MainMenu.SetActive(true);
        mm.Start();
    }
    void destroySound(){
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("ClickSound");
        for(int i = 0;i<sounds.Length;i++){
            Destroy(sounds[i]);
        }
    }
}
