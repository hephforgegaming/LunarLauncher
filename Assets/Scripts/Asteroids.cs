using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float speed = 7.5f;
    public AudioSource sound;
    public AudioClip clip;


    public Rigidbody2D theRB;

     void Start () 
     {
        if(ObstacleController.asteroidDirection <= 5){
             transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
        //Debug.Log("Going Right");
            theRB.velocity = transform.right * speed;
         } else if(ObstacleController.asteroidDirection > 5) {
             //Debug.Log("Going Left");
            theRB.velocity = -transform.right * speed;

         }
            sound.Play();
                      

 
     }
 
     void Update () 
     {


    }

        private void OnBecameInvisible()
    {

                Destroy(gameObject, clip.length);
    }
}
