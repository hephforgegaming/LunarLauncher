using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float spawnLocation;
    public GameObject asteroid;

private float time;
    public int minTime, maxTime, spawnTime;
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
        minTime = 2;
        maxTime = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time >= spawnTime)
        {
        SetRandomTime();
        SetRandomDirection();
        SpawnAsteroids();
        time = 0;
        }
    }

    private void SetRandomDirection()
    {
        asteroidDirection = Random.Range(0,9);
    }
    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime,maxTime);
                //Debug.Log("Waiting " + spawnTime + " second to spawn asteroid");

    }

    private void SpawnAsteroids()
    {
        if(spawnAsteroids == true)
        {
        if(asteroidDirection <= 5)
        {
            //Debug.Log("Shooting Right");
        spawnLocation = Mathf.Round(Random.Range(-2f,5f) * 100) / 100;
        Instantiate(asteroid, new Vector2(-10,spawnLocation), Quaternion.identity);
        } else if(asteroidDirection > 5) {
            //Debug.Log("Shooting Left");
        spawnLocation = Mathf.Round(Random.Range(-2f,5f) * 100) / 100;
        Instantiate(asteroid, new Vector2(11,spawnLocation), Quaternion.identity);
        }
        }
    }
}
