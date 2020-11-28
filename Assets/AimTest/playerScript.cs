using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class playerScript : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    public Vector3 initPos;
    public Rigidbody2D theRB;
    private Vector3 forceAtPlayer;
    public float forceFactor;
    public GameObject  reloadBall;  
    public float distance = 2f;
    public GameObject rockLauncher;
    
    public Sprite[] rockSkins;

    public GameObject trajectoryDot, nextBall, startScreen;

    private GameObject[] trajectoryDots;
    public int number;
    private bool canShoot = true;
    private bool launchable = false;
    private bool canReload = false;
    private bool blackHoled = false;
    public SpriteRenderer spriteRenderer;
         Ray ray;
     RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        var skin = Random.Range(0,3);
        spriteRenderer.sprite = rockSkins[skin];
        initPos = rockLauncher.transform.position;
        trajectoryDots = new GameObject[number];
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            canShoot = true;
        }

        if(canShoot == true){
        if(Input.GetMouseButtonDown(0)  &&  launchable == true) { //click

            startPos = rockLauncher.transform.position;
            for (int i = 0; i < number; i++)
            {
                trajectoryDots[i] = Instantiate(trajectoryDot, rockLauncher.transform);
            }
            
        }
        if(Input.GetMouseButton(0) && LevelTracker.canLoad == true  &&  launchable == true) { //drag

            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            //Debug.Log(endPos);
            if (Vector3.Distance(endPos, startPos) > distance)
            {
                rockLauncher.transform.position = startPos + (endPos - startPos).normalized * distance;
                forceAtPlayer = endPos - startPos;
            } else {
            rockLauncher.transform.position = endPos;
                        forceAtPlayer = endPos - startPos;
            }
            //gameObject.transform.position = endPos;
            //forceAtPlayer = endPos - startPos;
            for (int i = 0; i < number; i++)
            {
                trajectoryDots[i].transform.position = calculatePosition(i * 0.1f);
            }
        }
        if(Input.GetMouseButtonUp(0) && LevelTracker.canLoad == true  &&  launchable == true) { //leave
            GetComponent<AudioSource>().Play();  
            theRB.gravityScale = 1;
            theRB.velocity = new Vector2(-forceAtPlayer.x * forceFactor, -forceAtPlayer.y * forceFactor);
            for (int i = 0; i < number; i++)
            {
                Destroy(trajectoryDots[i]);
            }
            Attaractor.beAttracted = true;
            LevelTracker.ShotCounter();
            canShoot = false;
            launchable = false;
            StartCoroutine(RockSpawn());

        }
        /*if(Input.GetKey(KeyCode.Space)) {
        if(((transform.position.y < -7 || (transform.position.x < -9.5f) || (transform.position.x > 9.5f)) && LevelTracker.enemyCounter != 0) || blackHoled == true  && LevelTracker.enemyCounter != 0)
            {
                canReload = true;
            } else {
                canReload = false;
            }
            if(canReload == true){
                LaunchController.SpawnRock();
            var skin = Random.Range(0,3);
            spriteRenderer.sprite = rockSkins[skin];
            theRB.gravityScale = 0;
            theRB.velocity = Vector2.zero;
             gameObject.transform.position = initPos;
             canReload = false;
             Attaractor.beAttracted = false;
             blackHoled = false;
             //canShoot = true;
            }
            
        }*/
        }
    }

    void OnMouseEnter()
{
    //Debug.Log("Mouse over item " + gameObject.name);
    launchable = true;
   // do something, e.g. change the sprite or make a sound
}

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Blackhole")
        {
            Debug.Log("Oh no! I'm stuck!!");
            blackHoled = true;
        }
    }

    void OnMouseExit()
{
    //canShoot = false;
   // do something, e.g. change the sprite or make a sound
}

    private Vector2 calculatePosition(float elapsedTime) {
        return new Vector2(endPos.x, endPos.y) + //X0
                new Vector2(-forceAtPlayer.x * forceFactor, -forceAtPlayer.y * forceFactor) * elapsedTime + //ut
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime ;
    }

    public IEnumerator RockSpawn()
    {
                Debug.Log("Waiting to Spawn Ball");

        yield return new WaitForSeconds(1f);
        Debug.Log("Spawning Ball");
        LaunchController.SpawnRock();
                yield return new WaitForSeconds(5f);
                Destroy(gameObject);
    } 

}
