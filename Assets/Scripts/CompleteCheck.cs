using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteCheck : MonoBehaviour
{
    public GameObject gameComplete;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Stage10-completed") == 1)
        {
            Debug.Log("Game has been completed");
            gameComplete.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
