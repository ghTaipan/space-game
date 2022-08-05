using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIParrent : MonoBehaviour
{
    public Vector3 soundPosition;
    public bool buttonClicked;
    public virtual void destroySound(){
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("ClickSound");
        for(int i = 0;i<sounds.Length;i++){
            Destroy(sounds[i]);
        }
    }
    public virtual void FixedUpdate(){
        if(buttonClicked){
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
            foreach(GameObject gameObject in buttons){
                gameObject.GetComponent<Button>().interactable = false;
            }
            GameObject[] Levelbuttons = GameObject.FindGameObjectsWithTag("LevelButton");
            foreach(GameObject gameObject in Levelbuttons){
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        else{
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
            foreach(GameObject gameObject in buttons){
                gameObject.GetComponent<Button>().interactable = true;
            }
            GameObject[] Levelbuttons = GameObject.FindGameObjectsWithTag("LevelButton");
            foreach(GameObject gameObject in Levelbuttons){
                gameObject.GetComponent<Button>().enabled = true;
            }
        }
    }
}
