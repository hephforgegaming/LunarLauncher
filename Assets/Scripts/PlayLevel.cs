using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayLevel : MonoBehaviour
{
    public static PlayLevel instance;
    public GameObject levelManager;
    //public Transform  pathComplete;
    public static bool Stage1, Stage2, Stage3, Stage4, Stage5,
    Stage6, Stage7, Stage8, Stage9, Stage10;

    public string levelToLoad;
    private LevelManager levelManagerScript;
    
    public GameObject optionsScreen, loadingScreen, loadingIcon;

    private string levelName = "";

        public Text loadingText;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

    }

     void Start()
    {
        levelName = this.gameObject.name.ToString();
        PlayerPrefs.SetInt(levelName, 0);
        Debug.Log(PlayerPrefs.GetInt(levelName) + " is the stored value for " + levelName);
        
        
        //Debug.Log( this.gameObject.transform.GetChild(1).GetChild(0) + " is the child object selected.");
        levelManagerScript = levelManager.GetComponent<LevelManager>();

        //Debug.Log(levelManagerScript.lvl1Playable);
        //LevelTracker.levelBeingPlayed = gameObject.name.ToString();
        //Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if((gameObject.name == "Stage1" || gameObject.name == "Stage2") && Stage2 == true)
        {
            Debug.Log("Show Stage2 as active");
            this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            if(gameObject.name == "Stage1")
            {
            this.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            }
        } else if (Stage2 == false && gameObject.name != "Stage1"){
            this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        if(Stage2 == false)
        {
            this.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);

        }
    }

    private void OnMouseDown()
    {
        //isPlayable = true;
        if(gameObject.name == "Stage1")
        {
        if (levelManagerScript.Stage1 == true)
        {
        Debug.Log(gameObject.name);
        LevelTracker.levelBeingPlayed = gameObject.name.ToString();
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }    
        } else if(gameObject.name == "Stage2")
        {
        if (levelManagerScript.Stage2 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        } else if(gameObject.name == "Stage3")
        {
        if (levelManagerScript.Stage3 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        } else if(gameObject.name == "Stage4")
        {
        if (levelManagerScript.Stage4 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        }else if(gameObject.name == "Stage5")
        {
        if (levelManagerScript.Stage5 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        }else if(gameObject.name == "Stage6")
        {
        if (levelManagerScript.Stage6 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        }else if(gameObject.name == "Stage7")
        {
        if (levelManagerScript.Stage7 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        }else if(gameObject.name == "Stage8")
        {
        if (levelManagerScript.Stage8 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        }else if(gameObject.name == "Stage9")
        {
        if (levelManagerScript.Stage9 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        }else if(gameObject.name == "Stage10")
        {
        if (levelManagerScript.Stage10 == true)
        {
        Debug.Log(gameObject.name);
        Debug.Log("Loading " + levelToLoad);
                StartCoroutine(loadLevel());
        } else {
            Debug.Log(gameObject.name + " is locked, play to unlock");
        }  
            
        }

    }

    private void OnMouseUp()
    {

    }

        public IEnumerator loadLevel()
    {
        //ScoreTracker.scoreTracker.SetActive(false);
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);

        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= .9f)
            {
                loadingText.text = "Press any key to continue";
                loadingIcon.SetActive(false);
                if(Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }
    }

}
