using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTracker : MonoBehaviour
{
    public LevelManager unlockLevel;
    public static string levelBeingPlayed;

    //private LevelManager levelManagerScript;

    public GameObject levelCompleteScreen, levelStartScreen, scoreTracker;
    public static LevelTracker instance;
    public TextMeshProUGUI shotsCount, enemyCount, finalShotGoal, finalShotsFired, finalEnemiesKilled, startShotGoal, startEnemyCount, totalShots; 
     // Start is called before the first frame update

        public List<GameObject> enemies = new List<GameObject>();

        public bool openWhenEnemiesCleared;
        public static int shotsFired = 0;
        private int enemiesLeft, enemiesToKill;
        private int enemiesKilled = 0;
        public int shotGoal;


        //public RoomActivator theRoom;

        private void Awake()
    {
        instance = this;

    }


    void Start()
    {
        //levelManagerScript = levelManager.GetComponent<LevelManager>();

        enemiesLeft = enemies.Count;
        enemiesToKill = enemies.Count;
        startEnemyCount.text = enemiesToKill.ToString();
        startShotGoal.text = shotGoal.ToString();
        shotsFired = 0;

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
                    Debug.Log((i + 1) + " enemies left!");
                    enemiesKilled++;

                }
            

            if(enemies.Count == 0)
            {
                Debug.Log("Level Cleared!");
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
        Debug.Log(shotsFired + " shots fired!");

    }

        public void LevelComplete()
    {
        finalShotsFired.text = shotsFired.ToString();
        finalEnemiesKilled.text = enemiesKilled.ToString();
        finalShotGoal.text = shotGoal.ToString();
        levelCompleteScreen.SetActive(true);
        PlayerPrefs.SetInt("shots",PlayerPrefs.GetInt("shots") + shotsFired);

        Debug.Log(PlayerPrefs.GetInt(levelBeingPlayed));
    if(levelBeingPlayed == "Stage1")
        {
            Debug.Log(levelBeingPlayed + " has been completed");
            PlayerPrefs.SetInt("Stage2", 1);
             unlockLevel.Stage2 = true;
             Debug.Log("Enabling Stage 2");
        } else if(gameObject.name == "Stage2")
        {

        } else if(gameObject.name == "Stage3")
        {

        } else if(gameObject.name == "Stage4")
        {
             
        }else if(gameObject.name == "Stage5")
        {

        }else if(gameObject.name == "Stage6")
        {
            
        }else if(gameObject.name == "Stage7")
        {
           
        }else if(gameObject.name == "Stage8")
        {

        }else if(gameObject.name == "Stage9")
        {
            
        }else if(gameObject.name == "Stage10")
        {

 
        }  
            
        
    
    
    
    }

    public void StartLevel()
    {
        levelStartScreen.SetActive(false);
        scoreTracker.SetActive(true);
    }
}
