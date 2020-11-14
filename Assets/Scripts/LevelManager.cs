using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private static GameObject levelPlayed;
    public int Level1;
    public int Level2;
   // public string levelToLoad;
    
    //public GameObject optionsScreen, loadingScreen, loadingIcon;

        //public Text loadingText;

                private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
     void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Stage1", 1);
        Level1 =  PlayerPrefs.GetInt("Stage1");
        Level2 =  PlayerPrefs.GetInt("Stage2");
    }


}