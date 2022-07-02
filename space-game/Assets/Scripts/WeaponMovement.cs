using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
 
    // Update is called once per frame
    void Update()
    {
    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg - 90f;

        if(angle>= -90f){
            rb.rotation = angle;
        }
        else if (angle< -90f && rb.rotation > 0){
            rb.rotation = 90f;
        }
        else{}{
            if(angle < -90f && rb. rotation<0){
                 rb.rotation = -90f;
            }
        }
    }
}
