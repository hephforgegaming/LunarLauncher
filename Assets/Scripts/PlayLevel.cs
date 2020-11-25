using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayLevel : MonoBehaviour
{
    public static PlayLevel instance;
   
    public GameObject stageComplete, optionsScreen, loadingScreen, loadingIcon, nextLevel, currentLevel;
    public Text stageParTxt;
    public GameObject oneStar, twoStar, threeStar, starOutline, levelLock;
    public int stagePar;
        public Text loadingText;
        private bool isLoading;
    public static bool canPlay;
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
            stageComplete.SetActive(true);
            levelLock.SetActive(false);
            starOutline.SetActive(true);
            showStars();
        }
    }

    private void OnMouseDown()
    {
        if (isLoading == false && canPlay == true)
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
        oneStar.SetActive(true);
        twoStar.SetActive(true);
        threeStar.SetActive(true);
        }  else if (PlayerPrefs.GetInt(gameObject.name + "-shots") == (stagePar + 1))
        {
        oneStar.SetActive(true);
        twoStar.SetActive(true);
        } else if (PlayerPrefs.GetInt(gameObject.name + "-shots") == (stagePar + 2))
        {
            oneStar.SetActive(true);

        }
    }

        public IEnumerator loadLevel()
    {
        //ScoreTracker.scoreTracker.SetActive(false);
        loadingScreen.SetActive(true);
        isLoading = true;

        SceneManager.LoadSceneAsync(gameObject.name);

        //asyncLoad.allowSceneActivation = false;

        /*while(!asyncLoad.isDone)
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
        }*/
    yield return null;
    }


}
