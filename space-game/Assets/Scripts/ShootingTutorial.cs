using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingTutorial : UIParrent
{
    public GameObject TutorialPanel;
    public GameObject clickSound;
    public GameObject weapon;
    public GameObject weaponX;
    public GameObject next1;
    public GameObject next2;
    public GameObject next3;
    public GameObject enemy1;
    public GameObject[] bullets;
    private bool KillTutOn = false;
    private bool ReviveEnemy = true;
    private bool BackToTutScreen;
    private bool DestroyBulletNow = true;
    private Animator ShootTutAnim;
  
    public void Start(){
        BackToTutScreen = false;
        ShootTutAnim = GetComponent<Animator>();
        TutorialPanel.SetActive(false);
        soundPosition.x = 0;
        soundPosition.y = 0;
        next1.SetActive(true);
        soundPosition.z = 0;
    }
    public void WeaponMethods(){
        weapon = Instantiate(Resources.Load("TutorialWeapon")) as GameObject;
        weapon.transform.position = weaponX.transform.position;
        weapon.transform.rotation = weaponX.transform.rotation;
        weapon.transform.localScale = new Vector3(1,1,1);
        weapon.GetComponent<WeaponMovement>().enabled = false;
        weapon.GetComponent<Shooting>().enabled = false;
        weapon.GetComponent<TutorialShooting>().enabled = false;
    }
    private void WeaponMovementTut(){
        weapon.GetComponent<Animator>().enabled = false;
        weapon.GetComponent<WeaponMovement>().enabled = true;
        ShootTutAnim.SetTrigger("WPTutOn");
        next1.SetActive(false);
        next2.SetActive(true);
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
    }
    public void ShootTut(){
        ShootTutAnim.SetTrigger("ShootTutOn");
        next2.SetActive(false);
        next3.SetActive(true);
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        weapon.GetComponent<TutorialShooting>().enabled = true;
    }

    public void KillTut(){
        ShootTutAnim.SetTrigger("KillTutOn");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        next3.SetActive(false);
        KillTutOn = true;
    }
    private void BackToTutorialScreen(){
        BackToTutScreen = true;
        weapon.GetComponent<Animator>().enabled = true;
        Destroy(enemy1);
        KillTutOn = false;
        ShootTutAnim.SetTrigger("STOutro");
         weapon.GetComponent<Animator>().SetTrigger("WeaponTutOff");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Invoke("WaitTTScreen",0.7f);
    }
    private void WaitTTScreen(){
        Destroy(weapon);
        TutorialPanel.SetActive(true);
        TutorialPanel.GetComponent<Tutorial>().Start();
        TutorialPanel.GetComponent<Animator>().SetTrigger("Return");
    }
    protected override void destroySound(){
        base.destroySound();
    }
    protected override void FixedUpdate(){
        if(DestroyBulletNow){
            DestroyBulletNow = false;
            Invoke("DestroyBullet",5f);
        }
        if(KillTutOn == true && ReviveEnemy == true && enemy1 == null){
            ReviveEnemy = false;
            Invoke("reviveEnemy",1f);
        }
        base.FixedUpdate();
    }
    private void DestroyBullet(){
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject gameObject in bullets){
            Destroy(gameObject);
        }
        DestroyBulletNow = true;
    }
    private void boolRevive(){
        if(!BackToTutScreen){
            ReviveEnemy = true;
        }
    }
    private void reviveEnemy(){
        DestroyDeathSound();
        enemy1 = Instantiate(Resources.Load("Enemy1")) as GameObject;
        enemy1.transform.position = new Vector3 (0,4f,0);
        Invoke("boolRevive",0.1f);
    }
    private void DestroyDeathSound(){
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("DeathSound");
        for(int i = 0;i<sounds.Length;i++){
            Destroy(sounds[i]);
        }
    }
}
