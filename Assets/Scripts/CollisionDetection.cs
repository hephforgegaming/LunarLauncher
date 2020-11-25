using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public string objectHit;
    private int hidden = 1;
    private string planet;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hidden == 0 )
        {
            sprite.sortingOrder = 0;
            gameObject.layer = 10;
        }else if(hidden == 1 )
        {
            sprite.sortingOrder = 2;
            gameObject.layer = 9;
        }
    }

        private void OnCollisionEnter2D(Collision2D collision) {
        GameObject otherObj = collision.gameObject;
        //Debug.Log("Collided with: " + otherObj + " " + hidden);
    }
 
    private void OnTriggerEnter2D(Collider2D collider) {
        
        GameObject otherObj = collider.gameObject;
        planet = collider.gameObject.tag;

        if(otherObj.ToString() == "P2 (UnityEngine.GameObject)")
        {
            hidden = 0;
            //Debug.Log(hidden);
            //Debug.Log("Hidden set to 0");
            
        }
        if(otherObj.ToString() == "P1 (UnityEngine.GameObject)") {
            hidden = 1;
            
        }     
         //Debug.Log(planet);

        

    }
}
