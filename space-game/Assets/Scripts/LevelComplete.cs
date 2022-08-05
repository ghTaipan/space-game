using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
  public GameObject player;
  public GameObject wp;
  public GameObject LoadScene;
  public GameObject[] lasers;
  public GameObject[] plasmaBalls;
   public GameObject EscapeMenu;
  public GameObject ammo1;
  public GameObject ammo2;
  public GameObject ammo3;
  public GameObject ammo4;
  public Animator laser;
  public bool LCStarted = false;
  public bool startDebug = false;
  public void Start(){
    LCStarted = true;
    startDebug = true;
    EscapeMenu.GetComponent<EscPanel>().activate = false;
    lasers = GameObject.FindGameObjectsWithTag("Laser");
    plasmaBalls = GameObject.FindGameObjectsWithTag("PlasmaBall");
    wp.GetComponent<WeaponMovement>().Exit();
    Invoke("playerExit",1f);
    Invoke("wait",2.17f);
  }
  void playerExit(){
    laser.SetTrigger("LaserOff");
    player.GetComponent<Player>().Exit();
  }
  void wait(){
    //int sceeneIndex = SceneManager.GetActiveScene().buildIndex;
    if(FindObjectOfType<DoNotDestory>().levelNumber != 16){
        FindObjectOfType<DoNotDestory>().levelNumber++;
    }
    int sceeneIndex = FindObjectOfType<DoNotDestory>().levelNumber;
    if(SaveSystem.LoadLevel() <= sceeneIndex && sceeneIndex != 16){
      SaveSystem.SaveLevel(sceeneIndex + 1);
    }
    if(sceeneIndex ==4 || sceeneIndex == 8 || sceeneIndex == 12){
      EscapeMenu.GetComponent<EscPanel>().activate = true;
      FindObjectOfType<DoNotDestory>().nextMusic = false;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    else{
      EscapeMenu.SetActive(false);
      ammo1.SetActive(false);
      ammo2.SetActive(false);
      ammo3.SetActive(false);
      ammo4.SetActive(false);
      FindObjectOfType<GameManager>().Start();
      EscapeMenu.SetActive(true);
      EscapeMenu.GetComponent<EscPanel>().Start();
      LoadScene.SetActive(true);
      ammo1.SetActive(true);
      ammo2.SetActive(true);
      ammo3.SetActive(true);
      ammo4.SetActive(true);
      player.GetComponent<Animator>().SetTrigger("TriEnter");
      wp.GetComponent<Animator>().SetTrigger("TriOn");
      wp.GetComponent<WeaponMovement>().enabled = true;
      wp.GetComponent<WeaponMovement>().waited = false;
      wp.GetComponent<Rigidbody2D>().rotation = 0;
      wp.GetComponent<WeaponMovement>().Start();
      FindObjectOfType<Shooting>().index = 0;
      FindObjectOfType<Shooting>().ammoCount = 4;
      LCStarted = false;
      gameObject.SetActive(false);  
    }
  }

}
