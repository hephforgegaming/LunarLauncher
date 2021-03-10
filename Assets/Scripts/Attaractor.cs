using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaractor : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public static bool beAttracted = false; 
    public static Attaractor instance;
        private void Awake()
    {
        instance = this;

    }
    void FixedUpdate()
    {
        Attaractor[] attractors = FindObjectsOfType<Attaractor>();
        foreach(Attaractor attractor in attractors)
        {
            if(attractor != this)
            {
                if(beAttracted == true)
                {
                    Attract(attractor);
                }
                            
            }
        }
    }

    void Attract(Attaractor objectToAttract)
    {

        Rigidbody2D rbToAttract = objectToAttract.rb;
        Vector3 direction = rb.position - rbToAttract.position;

        float distance = direction.magnitude;
        float forceMagnitude = (rb.mass * 3 * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
        

    }

}
