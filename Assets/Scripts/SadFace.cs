using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadFace : MonoBehaviour
{
    public GameObject sadFace;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
 GameObject item;
 Transform tmp = this.transform.Find("Enemy");
 if (tmp == null)
 {
     //Debug.Log("Not found");
     sadFace.SetActive(true);
    }  
 else
 {
     item = tmp.gameObject;
     //Debug.Log("Found");
 }
    }
}
