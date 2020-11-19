using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float speed = 7.5f;


    public Rigidbody2D theRB;

     void Start () 
     {
      
 
     }
 
     void Update () 
     {
         if(ObstacleController.asteroidDirection < 5){
            theRB.velocity = transform.right * speed;
         } else {
            theRB.velocity = -transform.right * speed;

         }

    }

        private void OnBecameInvisible()
    {

                Destroy(gameObject);
    }
}
