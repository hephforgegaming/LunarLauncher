using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTracker : MonoBehaviour
{
    public LevelManager unlockLevel;
    public static string levelBeingPlayed, currentLevel, bestShots, levelCompleted;

    //private LevelManager levelManagerScript;

    public GameObject levelCompleteScreen, levelStartScreen, scoreTracker, finalScore;
    public static LevelTracker instance;
    public TextMeshProUGUI shotsCount, enemyCount, finalShotGoal, finalShotsFired, finalEnemiesKilled, startShotGoal, startEnemyCount, totalShots, bestScore; 
     // Start is called before the first frame update

        public List<GameObject> enemies = new List<GameObject>();

        public bool openWhenEnemiesCleared;
        public static int shotsFired = 0;
        private int enemiesLeft, enemiesToKill;
        private int enemiesKilled = 0;
        public int shotGoal;
        private int shotTotal, bestShot;


        //public RoomActivator theRoom;

        private void Awake()
    {
        instance = this;

    }


    void Start()
    {

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
        bestScore.text = PlayerPrefs.GetInt(bestShots).ToString();

    }

    // Update is called once per frame
    void Update()
    {

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
            

            if(enemies.Count == 0)
            {
                //Debug.Log("Level Cleared!");
                LevelComplete();            
            }
        }

        shotsCount.text = shotsFired.ToString();
        enemyCount.text = enemiesLeft.ToString();
    }

    public static void ShotCounter()
    {
        //Debug.Log(shotsFired + " shots fired!");
        shotsFired++;
        //Debug.Log(shotsFired + " shots fired!");

    }

        public void LevelComplete()
    {
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
        } else if (shotsFired < PlayerPrefs.GetInt(bestShots))
        {
            Debug.Log(shotTotal);
            PlayerPrefs.SetInt(bestShots, shotsFired);
            PlayerPrefs.SetInt("shots",PlayerPrefs.GetInt("shots") - bestShot + shotsFired);
        }

        if(currentLevel == "Stage10")
        {
            Debug.Log("This is the last level");
            PlayerPrefs.SetInt("HighScore",PlayerPrefs.GetInt("shots"));
            Debug.Log("High Score is: " + PlayerPrefs.GetInt("HighScore"));

        }
    
    }

    public void StartLevel()
    {
        levelStartScreen.SetActive(false);
        scoreTracker.SetActive(true);
        Time.timeScale = 1f;
    }
}
