using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{

    public GameObject scoreTracker;
    private  ScoreTracker instance;
    public  TextMeshProUGUI totalShots; 
    private int shotsFired = 0;
     // Start is called before the first frame update

              //public RoomActivator theRoom;

        private void Awake()
    {
        instance = this;

    }


    void Start()
    {        
        totalShots.text = PlayerPrefs.GetInt("shots").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        totalShots.text = PlayerPrefs.GetInt("shots").ToString();
    }


}

