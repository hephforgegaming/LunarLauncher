using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPlanetDetection : MonoBehaviour
{
    public string objectHit;
    private int hidden = 1;
    private string planet;
    private SpriteRenderer sprite;
    public SpriteRenderer basePlanet;
    public GameObject rp1, rp2;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Debug.Log(basePlanet.sortingOrder);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rp1.ToString());
        if(hidden == 0 )
        {
            
            sprite.sortingOrder = basePlanet.sortingOrder - 1;
            //gameObject.layer = 10;
        }else if(hidden == 1 )
        {
            sprite.sortingOrder = basePlanet.sortingOrder + 1;
            //gameObject.layer = 9;
        }
    }

        private void OnCollisionEnter2D(Collision2D collision) {
        GameObject otherObj = collision.gameObject;
        //Debug.Log("Collided with: " + otherObj + " " + hidden);
    }
 
    private void OnTriggerEnter2D(Collider2D collider) {
        
        GameObject otherObj = collider.gameObject;
        planet = collider.gameObject.tag;

        if(otherObj.ToString() == rp2.ToString())
        {
            hidden = 0;
            //Debug.Log(hidden);
            //Debug.Log("Hidden set to 0");
            
        }
        if(otherObj.ToString() == rp1.ToString()) {
            hidden = 1;
            
        }     
         //Debug.Log(planet);

        

    }
}
