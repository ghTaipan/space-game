using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
  public Player player;
  public WeaponMovement wp;
  public Animator laser;
  void Start(){
    wp.Exit();
    Invoke("playerExit",1f);
    Invoke("wait",2.5f);
  }
  void playerExit(){
    laser.SetTrigger("LaserOff");
    player.Exit();
  }
  void wait(){
    int sceeneIndex = SceneManager.GetActiveScene().buildIndex;
    if(sceeneIndex ==4 || sceeneIndex == 8 || sceeneIndex == 12){
      FindObjectOfType<DoNotDestory>().nextMusic = false;
    }
    if(SaveSystem.LoadLevel() <= sceeneIndex && sceeneIndex != 16){
      SaveSystem.SaveLevel(sceeneIndex + 1);
    }
    SceneManager.LoadScene(sceeneIndex + 1);
  }

}
