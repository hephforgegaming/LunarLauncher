using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLevel : MonoBehaviour
{
    public DemoLevel instance;
    public GameObject shotExp, enemiesExp, continueExp, targetExp, launchExp, totShotsExp, totEnemiesExp;
    public static bool canClick = false;

    public static GameObject gblLaunchExp;

    // Start is called before the first frame update
            private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        gblLaunchExp = launchExp;
        StartCoroutine(LevelDemo());
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelTracker.beenClicked == true)
        {
            StartCoroutine(LevelDemo1());
        }
    }

    public IEnumerator LevelDemo()
    {
        yield return new WaitForSeconds(1f);
        shotExp.SetActive(true);
        yield return new WaitForSeconds(2f);
        shotExp.SetActive(false);
        enemiesExp.SetActive(true);
        yield return new WaitForSeconds(2f);
        enemiesExp.SetActive(false);
        continueExp.SetActive(true);
        canClick = true;

    }

        public IEnumerator LevelDemo1()
    {
        yield return new WaitForSeconds(1f);
        targetExp.SetActive(true);
        LevelTracker.beenClicked = false;
        yield return new WaitForSeconds(2f);
        targetExp.SetActive(false);
        totShotsExp.SetActive(true);
        yield return new WaitForSeconds(2f);
        totShotsExp.SetActive(false);
        totEnemiesExp.SetActive(true);
        yield return new WaitForSeconds(2f);
        totEnemiesExp.SetActive(false);
        launchExp.SetActive(true);
        LevelTracker.canLoad = true;
        PlayerPrefs.SetInt("DemoComplete",1);


    }
}
