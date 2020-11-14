using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayLevel : MonoBehaviour
{
    public static PlayLevel instance;
   
    public GameObject optionsScreen, loadingScreen, loadingIcon, nextLevel, currentLevel;
    public Text stageParTxt;
    public int stagePar;
        public Text loadingText;
        private bool isLoading;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

    }

     void Start()
    {
        //stageParTxt.text = stagePar.ToString();
        PlayerPrefs.SetInt(gameObject.name + "-par", stagePar);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(gameObject.name)  == 1)
        {
             this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            showStars();
        }
    }

    private void OnMouseDown()
    {
        if (isLoading == false)
        {
        //isPlayable = true;
        if(PlayerPrefs.GetInt(gameObject.name)  == 1 && PlayerPrefs.GetInt(gameObject.name + "-completed") != 1)
        {
        //Debug.Log(gameObject.name);
        //Debug.Log(nextLevel.name + " is the next level");
        LevelTracker.levelBeingPlayed = nextLevel.name.ToString();
        LevelTracker.currentLevel = gameObject.name.ToString();
        //Debug.Log("Loading level " + gameObject.name);
                StartCoroutine(loadLevel());
        } else if(PlayerPrefs.GetInt(gameObject.name + "-completed") == 1) {
            Debug.Log("Level already completed");
            //Debug.Log("Stored pref is: " + PlayerPrefs.GetInt(gameObject.name));
        }  
        
        }
    }

    public void showStars()
    {
        if (PlayerPrefs.GetInt(gameObject.name + "-shots") <= stagePar && PlayerPrefs.GetInt(gameObject.name + "-shots") != 0)
        {
        this.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
        }  else if (PlayerPrefs.GetInt(gameObject.name + "-shots") == (stagePar + 1))
        {
        this.gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        } else if (PlayerPrefs.GetInt(gameObject.name + "-shots") == (stagePar + 2))
        {
        this.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }
    }

        public IEnumerator loadLevel()
    {
        //ScoreTracker.scoreTracker.SetActive(false);
        loadingScreen.SetActive(true);
        isLoading = true;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameObject.name);

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
