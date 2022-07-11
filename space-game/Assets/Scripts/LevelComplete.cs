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
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

}
