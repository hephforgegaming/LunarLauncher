using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject optionsScreen, pauseScreen, finalScore, loadingScreen, loadingIcon;
    public string mainMenuScene, worldMapScene;

    public Text loadingText;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(!isPaused)
        {
            PlayLevel.canPlay = false;
            pauseScreen.SetActive(true);
            isPaused = true;

            Time.timeScale = 0f;
        } else {
            PlayLevel.canPlay = true;
            pauseScreen.SetActive(false);
            isPaused = false;

            Time.timeScale = 1f;
        }
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void ExitLevel()
    {
        //SceneManager.LoadScene(mainMenuScene);

        //Time.timeScale = 1f;
        StartCoroutine(exitLevel());
    }

    public void QUitToMain()
    {
        //Time.timeScale = 1f;
        StartCoroutine(loadMain());
    }

    public IEnumerator loadMain()
    {
        loadingScreen.SetActive(true);
        finalScore.SetActive(false);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainMenuScene);

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

        public IEnumerator exitLevel()
    {
        //loadingScreen.SetActive(true);

        SceneManager.LoadSceneAsync(worldMapScene);

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
            }*/

            yield return null;
        }
    
}
