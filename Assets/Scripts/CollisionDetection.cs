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
            //Debug.Log("Hidden set to 0");
            
        } else if(hidden == 0 && planet == "Planet"  )
        {
            Debug.Log("Moon Hidden");
            sprite.sortingOrder = -5;
            gameObject.layer = 10;
        } else if(otherObj.ToString() == "P1 (UnityEngine.GameObject)") {
            hidden = 1;
        } else {
            //Debug.Log("Collided with: " + otherObj + " " + hidden);

        }       
        

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        planet = collider.gameObject.tag;
        if(otherObj.ToString() == "Planet (UnityEngine.GameObject)"  )
        {
            Debug.Log("Moon Shown");
            sprite.sortingOrder = 2;
            gameObject.layer = 9;
            //gameObject.SetActive(true);
        } else {
        //Debug.Log("Exited trigger with: " + otherObj + " " + hidden);
        }
    }
}
