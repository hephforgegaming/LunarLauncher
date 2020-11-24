using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionPlanet : MonoBehaviour
{
    public string objectHit;
    private int hidden = 1;
    private SpriteRenderer sprite;
    public GameObject rp1, rp2;
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
            sprite.sortingOrder = -2;
        }else if(hidden == 1 )
        {
            sprite.sortingOrder = 1;
        }
    }
    
 
    private void OnTriggerEnter2D(Collider2D collider) {
        
        GameObject otherObj = collider.gameObject;

        if(otherObj.ToString() == "M2 (UnityEngine.GameObject)")
        {
            Debug.Log(otherObj + " " + gameObject.name);
            hidden = 0;
            Debug.Log(hidden);
            //Debug.Log("Hidden set to 0");
            
        }
        if(otherObj.ToString() == "M1 (UnityEngine.GameObject)") {
            Debug.Log(otherObj + " " + gameObject.name);
            hidden = 1;
             Debug.Log(hidden);
            
        }     
         //Debug.Log(planet);

        

    }
}