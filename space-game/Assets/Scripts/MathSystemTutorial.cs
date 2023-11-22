using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathSystemTutorial : UIParrent
{
    public GameObject TutorialPanel;
    public GameObject clickSound;
    private Animator MathTutAnim;
    public void Start()
    {
        TutorialPanel.SetActive(false);
        MathTutAnim = GetComponent<Animator>();
    }

    public void FirstTutPart(){
        MathTutAnim.SetTrigger("MTFirst");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
    }
    public void SecondTutPart(){
        MathTutAnim.SetTrigger("MTSecond");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
    }
    private void BackToTutorialScreen(){
        MathTutAnim.SetTrigger("MTOutro");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("WaitTTScreen",1f);
    }
    private void WaitTTScreen(){
        TutorialPanel.SetActive(true);
        TutorialPanel.GetComponent<Tutorial>().Start();
        TutorialPanel.GetComponent<Animator>().SetTrigger("Return");
    }
    protected override void destroySound(){
        base.destroySound();
    }
    protected override void FixedUpdate(){
        base.FixedUpdate();
    }
}
