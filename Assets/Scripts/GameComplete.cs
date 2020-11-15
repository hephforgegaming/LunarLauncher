using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour
{

    public GameObject gameComplete, loadingScreen, loadingIcon;
    public string mainMenuScene, worldMapScene;

    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

        public void QUitToMain()
    {
        //Time.timeScale = 1f;
        gameComplete.SetActive(false);
        StartCoroutine(loadMain());
    }

     public void ResetProgress()
    {
        gameComplete.SetActive(false);
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


        public IEnumerator loadMain()
    {

        loadingScreen.SetActive(true);

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
}
