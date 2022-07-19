using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Shooting shooting;
    private Animator weaponAnimator;
    int rot = 90;
    
    public bool waited = false;
 
    // Update is called once per frame
    public void Start(){
        weaponAnimator = GetComponent<Animator>();
        weaponAnimator.SetTrigger("TriOn");
        shooting.enabled = false;
        if(weaponAnimator.isActiveAndEnabled){
            Invoke("enableShooting",1.3f);
        }
        else{
            waited = true;
        }
        
    }
    void enableShooting(){
         shooting.enabled = true;
         waited = true;
    }
    public void Exit(){
        shooting.enabled = false;
        weaponAnimator.SetTrigger("TriOff");
        Invoke("destoryWP",1f);
    }
    void destoryWP(){
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        if(waited == true){
            if (rb.rotation > 60 || rb.rotation < -60){
                rot *= -1;
                gameObject.transform.Rotate(0,0,rot* (Time.deltaTime*1.5f));
            }
            else{
                gameObject.transform.Rotate(0,0,rot* (Time.deltaTime*1.5f));
             }
        }  
    }
}
