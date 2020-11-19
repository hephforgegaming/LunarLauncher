using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float spawnLocation;
    public GameObject asteroid;

    public float minTime, maxTime, time, sapwnTime;
    public bool spawnAsteroids, createBlackholes;
    public static int asteroidDirection;
    public static ObstacleController instance;

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        minTime = 2f;
        maxTime = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time >= sapwnTime)
        {
        SpawnAsteroids();
        SetRandomTime();
        SetRandomDirection();
        time = 0;
        }
    }

    private void SetRandomDirection()
    {
        asteroidDirection = Random.Range(0,9);
    }
    private void SetRandomTime()
    {
        sapwnTime = Random.Range(minTime,maxTime);
    }

    private void SpawnAsteroids()
    {
        if(spawnAsteroids == true)
        {
        if(asteroidDirection < 5)
        {
        spawnLocation = Mathf.Round(Random.Range(-2f,5f) * 100) / 100;
        Instantiate(asteroid, new Vector2(-7,spawnLocation), Quaternion.identity);
        } else {
        spawnLocation = Mathf.Round(Random.Range(-2f,5f) * 100) / 100;
        Instantiate(asteroid, new Vector2(11,spawnLocation), Quaternion.identity);
        }
        }
    }
}
