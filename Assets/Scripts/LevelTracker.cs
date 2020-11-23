using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTracker : MonoBehaviour
{
    public LevelManager unlockLevel;
    public static string gameComplete, levelBeingPlayed, currentLevel, bestShots, levelCompleted;

    //private LevelManager levelManagerScript;
    public static int enemyCounter;
    public GameObject loadBall, rockLauncher, levelCompleteScreen, levelStartScreen, scoreTracker, finalScore;
    public static LevelTracker instance;
    public TextMeshProUGUI levelTitle, shotsCount, enemyCount, finalShotGoal, finalShotsFired, finalEnemiesKilled, startShotGoal, startEnemyCount, totalShots, bestScore; 
     // Start is called before the first frame update
public GameObject highScoreText;
        public List<GameObject> enemies = new List<GameObject>();

        public static bool canLoad = false;
        public static int shotsFired = 0;
        private int enemiesLeft, enemiesToKill;
        private int enemiesKilled = 0;
        public int shotGoal;
        private int shotTotal, bestShot;
        private string stageName;


        //public RoomActivator theRoom;

        private void Awake()
    {
        instance = this;

    }


    void Start()
    {
        var m_scene = SceneManager.GetActiveScene();
        stageName = m_scene.name;
        Debug.Log(stageName);
        loadBall.SetActive(true);
        Debug.Log(currentLevel + " is being played");
        levelTitle.text = stageName.ToString();
        Time.timeScale = 0f;
        bestShots = currentLevel + "-shots";
        levelCompleted = currentLevel + "-completed";
        //levelManagerScript = levelManager.GetComponent<LevelManager>();
        shotTotal = PlayerPrefs.GetInt("shots");
        enemiesLeft = enemies.Count;
        enemiesToKill = enemies.Count;
        startEnemyCount.text = enemiesToKill.ToString();
        startShotGoal.text = shotGoal.ToString();
        shotsFired = 0;
        bestShot = PlayerPrefs.GetInt(bestShots);
        Debug.Log(PlayerPrefs.GetInt(bestShots) + " is you best score for this level");
        //bestScore.text = PlayerPrefs.GetInt(bestShots).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canLoad == true)
        {
            loadBall.SetActive(false);
            rockLauncher.SetActive(true);
        }

            for(int i = 0; i < enemies.Count; i++)
            {

                if(enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                    i--;
                    enemiesLeft--;
                    //Debug.Log((i + 1) + " enemies left!");
                    enemiesKilled++;

                }
            

            if(enemies.Count == 0 && stageName != "Stage10")
            {
                Debug.Log("Level Cleared!");
                LevelComplete();        
                canLoad = false;    
            } else if(enemies.Count == 0 && stageName == "Stage10" ){
                canLoad = false;
                Debug.Log("Game Over!");
                gameEnd();
            }
        }

        shotsCount.text = shotsFired.ToString();
        enemyCount.text = enemiesLeft.ToString();
        enemyCounter = enemiesLeft;
    }

    public static void ShotCounter()
    {
        //Debug.Log(shotsFired + " shots fired!");
        shotsFired++;
        //Debug.Log(shotsFired + " shots fired!");

    }

        public void LevelComplete()
    {
        canLoad = false;
        Debug.Log("Level Complete Function");
        //Debug.Log(levelBeingPlayed + " is the next level");
        finalShotsFired.text = shotsFired.ToString();
        finalEnemiesKilled.text = enemiesKilled.ToString();
        finalShotGoal.text = shotGoal.ToString();
        levelCompleteScreen.SetActive(true);
        PlayerPrefs.SetInt(levelBeingPlayed, 1);
        PlayerPrefs.SetInt(levelCompleted, 1);
        if(PlayerPrefs.GetInt(bestShots) == 0 )
        {
            Debug.Log(shotTotal);
            PlayerPrefs.SetInt(bestShots, shotsFired);
            PlayerPrefs.SetInt("shots",PlayerPrefs.GetInt("shots") + shotsFired);
        } 
    }

    public void gameEnd()
    {
        canLoad = false;
        int currentHighScore =  PlayerPrefs.GetInt("HighScore");
        Debug.Log("Game End Function");
        //Debug.Log(levelBeingPlayed + " is the next level");
        finalScore.SetActive(true);
        PlayerPrefs.SetInt(levelBeingPlayed, 1);
        PlayerPrefs.SetInt(levelCompleted, 1);
        PlayerPrefs.SetInt(bestShots, shotsFired);
        PlayerPrefs.SetInt("shots",PlayerPrefs.GetInt("shots") + shotsFired);
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("shots"));       

        if(PlayerPrefs.GetInt("HighScore") < currentHighScore)
        {
            highScoreText.SetActive(true);
        }
    
    }

    public void StartLevel()
    {
        levelStartScreen.SetActive(false);
        scoreTracker.SetActive(true);
        canLoad = true;
        Time.timeScale = 1f;
    }
}
