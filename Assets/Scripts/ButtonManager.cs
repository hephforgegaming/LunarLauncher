using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject btnOptions, btnQuit;
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_IOS
            Debug.Log("iPhone");
            if (btnOptions != null){
                btnOptions.SetActive(false);
            }
            if (btnQuit != null){
            btnQuit.SetActive(false);
            }
        #endif
        //Debug.Log("iPhone");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
