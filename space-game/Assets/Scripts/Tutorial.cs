using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : UIParrent
{
    public GameObject ShootingTutorialPanel;
    public GameObject EnemyTutorialPanel;
    public GameObject MainMenu;
    public GameObject clickSound;
    private Animator TutAnim;  
    public void Start(){
        buttonClicked = false;
        MainMenu.SetActive(false);
        ShootingTutorialPanel.SetActive(false);
        EnemyTutorialPanel.SetActive(false);
        TutAnim = GetComponent<Animator>();
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
    }
    public void playAnim(){
        TutAnim.SetTrigger("Start");
    }
    public void ShootingTutorial(){
        buttonClicked = true;
        TutAnim.SetTrigger("Button");
        Invoke("waitForST",1.7f);
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
    }
    private void waitForST(){
        ShootingTutorialPanel.SetActive(true);
        ShootingTutorialPanel.GetComponent<ShootingTutorial>().Start();
        ShootingTutorialPanel.GetComponent<ShootingTutorial>().WeaponMethods();
        ShootingTutorialPanel.GetComponent<Animator>().SetTrigger("STIntro");
        ShootingTutorialPanel.GetComponent<ShootingTutorial>().weapon.GetComponent<Animator>().SetTrigger("WeaponTutOn");
    }
    public void EnemyTutorial(){
        buttonClicked = true;
        TutAnim.SetTrigger("Button");
        Invoke("waitForET",1.7f);
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
    }
    private void waitForET(){
        EnemyTutorialPanel.SetActive(true);
        EnemyTutorialPanel.GetComponent<EnemyTutorial>().Start();
        EnemyTutorialPanel.GetComponent<EnemyTutorial>().instEnemy();
        EnemyTutorialPanel.GetComponent<Animator>().SetTrigger("ETIntro");
    }
    public void BackToMainMenu(){
        buttonClicked = true;
        TutAnim.SetTrigger("ReturnToMM");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("WaitMMScreen",0.67f);
    }
    private void WaitMMScreen(){ 
        MainMenu.SetActive(true);
        MainMenu.GetComponent<MainMenu>().Start();
    }
    protected override void destroySound(){
        base.destroySound();
    }
    protected override void FixedUpdate(){
        base.FixedUpdate();
    }
}
