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
    private Rigidbody2D rigidbody;
    private Vector3 forceAtPlayer;
    public float forceFactor;
    public GameObject  reloadBall;  
    public float distance = 2f;

    public GameObject trajectoryDot, nextBall, startScreen;

    private GameObject[] trajectoryDots;
    public int number;
    private bool canShoot = true;
    private bool canReload = false;
    private bool blackHoled = false;
    


    // Start is called before the first frame update
    void Start()
    {
        initPos = gameObject.transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        trajectoryDots = new GameObject[number];
    }

    // Update is called once per frame
    void Update()
    {
        if(((transform.position.y < -7 || (transform.position.x < -9.5f) || (transform.position.x > 9.5f)) && LevelTracker.enemyCounter != 0) || blackHoled == true  && LevelTracker.enemyCounter != 0)
            {
                reloadBall.SetActive(true);
            } else {
                reloadBall.SetActive(false);
            }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canShoot = true;
        }

        if(canShoot == true){
        if(Input.GetMouseButtonDown(0)) { //click

            startPos = gameObject.transform.position;
            for (int i = 0; i < number; i++)
            {
                trajectoryDots[i] = Instantiate(trajectoryDot, gameObject.transform);
            }
            
        }
        if(Input.GetMouseButton(0)) { //drag

            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            //Debug.Log(endPos);
            if (Vector3.Distance(endPos, startPos) > distance)
            {
                gameObject.transform.position = startPos + (endPos - startPos).normalized * distance;
                forceAtPlayer = endPos - startPos;
            } else {
            gameObject.transform.position = endPos;
                        forceAtPlayer = endPos - startPos;
            }
            //gameObject.transform.position = endPos;
            //forceAtPlayer = endPos - startPos;
            for (int i = 0; i < number; i++)
            {
                trajectoryDots[i].transform.position = calculatePosition(i * 0.1f);
            }
        }
        if(Input.GetMouseButtonUp(0)) { //leave
            GetComponent<AudioSource>().Play();  
            rigidbody.gravityScale = 1;
            rigidbody.velocity = new Vector2(-forceAtPlayer.x * forceFactor, -forceAtPlayer.y * forceFactor);
            for (int i = 0; i < number; i++)
            {
                Destroy(trajectoryDots[i]);
            }
            Attaractor.beAttracted = true;
            LevelTracker.ShotCounter();
        }
        if(Input.GetKey(KeyCode.Space)) {
        if(((transform.position.y < -7 || (transform.position.x < -9.5f) || (transform.position.x > 9.5f)) && LevelTracker.enemyCounter != 0) || blackHoled == true  && LevelTracker.enemyCounter != 0)
            {
                canReload = true;
            } else {
                canReload = false;
            }
            if(canReload == true){
            rigidbody.gravityScale = 0;
            rigidbody.velocity = Vector2.zero;
             gameObject.transform.position = initPos;
             canReload = false;
             Attaractor.beAttracted = false;
             blackHoled = false;
            }
            
        }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Blackhole")
        {
            Debug.Log("Oh no! I'm stuck!!");
            blackHoled = true;
        }
    }

    private Vector2 calculatePosition(float elapsedTime) {
        return new Vector2(endPos.x, endPos.y) + //X0
                new Vector2(-forceAtPlayer.x * forceFactor, -forceAtPlayer.y * forceFactor) * elapsedTime + //ut
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime ;
    }

}
