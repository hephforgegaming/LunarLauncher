using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public GameObject optionsScreen, loadingScreen, loadingIcon, finalScore, creditsScreen;

        public Text loadingText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        finalScore.SetActive(false);
        //SceneManager.LoadScene(firstLevel);

        StartCoroutine(loadStart());
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

        public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

        public void ResetProgress()
    {
         finalScore.SetActive(false);
        PlayerPrefs.SetInt("shots", 0);
        for(int i = 0; i < 11; i++)
        {
            PlayerPrefs.SetInt("Stage" + i, 0);
            PlayerPrefs.SetInt("Stage" + i + "-completed", 0);
            PlayerPrefs.SetInt("Stage" + i + "-shots", 0);
        }
        
        //PlayerPrefs.SetInt("Stage2", 0);
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("All game values reset");
    }

        public IEnumerator loadStart()
    {
        //loadingScreen.SetActive(true);

        SceneManager.LoadSceneAsync(firstLevel);

        /*asyncLoad.allowSceneActivation = false;

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

            
        }*/
        yield return null;
    }
}
