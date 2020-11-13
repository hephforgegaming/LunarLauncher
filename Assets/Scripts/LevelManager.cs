using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
   // public string levelToLoad;
    public bool Stage1, Stage2, Stage3, Stage4, Stage5,
    Stage6, Stage7, Stage8, Stage9, Stage10;


    
    //public GameObject optionsScreen, loadingScreen, loadingIcon;

        //public Text loadingText;

                private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
     void Start()
    {
       Debug.Log(PlayerPrefs.GetInt("Stage2") + " is the current value for Stage2");
//Debug.Log(PlayerPrefs.GetInt(LevelTracker.levelBeingPlayed));
         //Debug.Log(LevelTracker.levelBeingPlayed);

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Stage2") == 1)
        {
            Debug.Log("Level 2 is unlocked");
            Stage2 = true;
            PlayLevel.Stage2 = true;
        } else {
            Debug.Log("Level 2 is Locked");
            //Stage2 = false;
            //PlayLevel.Stage2 = false;
        }
    }


}