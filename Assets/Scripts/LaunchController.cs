using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    private  LaunchController instance;
    public  GameObject rockLauncher, spawnLocation;
        public static GameObject rockLauncher1, spawnLocation1;

    // Start is called before the first frame update
    private void Awake()
        {
        instance = this;
        rockLauncher1 = rockLauncher;
        spawnLocation1 = spawnLocation;

    }

    void Start()
    {
        SpawnRock();
    }

    // Update is called once per frame     
    void FixedUpdate()
    {
        //if(Input.GetKey(KeyCode.Space)) {
          //  SpawnRock();
        //}
    }

    public static void  SpawnRock()
    {
        Debug.Log("Spawning new rock");
        Instantiate(rockLauncher1, spawnLocation1.transform.position, Quaternion.identity);

    }
}
