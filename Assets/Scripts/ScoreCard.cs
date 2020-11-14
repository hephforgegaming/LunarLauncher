using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCard : MonoBehaviour
{
    // Start is called before the first frame update
    public Text stage1Score, stage2Score, stage3Score, stage4Score, stage5Score, 
        stage6Score, stage7Score, stage8Score, stage9Score, stage10Score, scoreTot, parTot;
    
    public GameObject scoreCard;
    private int parTotal;
        
    private bool isScoreCard;
    void Start()
    {
        parTotal = 
            PlayerPrefs.GetInt("Stage1-par") + 
            PlayerPrefs.GetInt("Stage2-par") + 
            PlayerPrefs.GetInt("Stage3-par") + 
            PlayerPrefs.GetInt("Stage4-par") + 
            PlayerPrefs.GetInt("Stage5-par") + 
            PlayerPrefs.GetInt("Stage6-par") + 
            PlayerPrefs.GetInt("Stage7-par") + 
            PlayerPrefs.GetInt("Stage8-par") + 
            PlayerPrefs.GetInt("Stage9-par") + 
            PlayerPrefs.GetInt("Stage10-par");

        parTot.text = parTotal.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ShowScoreCard();
        }

        //Update Scores
        stage1Score.text = PlayerPrefs.GetInt("Stage1-shots").ToString();
        stage2Score.text = PlayerPrefs.GetInt("Stage2-shots").ToString();  
        stage3Score.text = PlayerPrefs.GetInt("Stage3-shots").ToString();  
        stage4Score.text = PlayerPrefs.GetInt("Stage4-shots").ToString();  
        stage5Score.text = PlayerPrefs.GetInt("Stage5-shots").ToString();  
        stage6Score.text = PlayerPrefs.GetInt("Stage6-shots").ToString();  
        stage7Score.text = PlayerPrefs.GetInt("Stage7-shots").ToString();
        stage8Score.text = PlayerPrefs.GetInt("Stage8-shots").ToString();  
        stage9Score.text = PlayerPrefs.GetInt("Stage9-shots").ToString();  
        stage10Score.text = PlayerPrefs.GetInt("Stage10-shots").ToString();
        //scoreTot.text = PlayerPrefs.GetInt("shots").ToString();
        scoreTot.text = PlayerPrefs.GetInt("shots").ToString();       
    }

    public void ShowScoreCard()
    {
        if(!isScoreCard)
        {
            scoreCard.SetActive(true);
            isScoreCard = true;

            Time.timeScale = 0f;
        } else {
            scoreCard.SetActive(false);
            isScoreCard = false;

            Time.timeScale = 1f;
        }
    }


}
