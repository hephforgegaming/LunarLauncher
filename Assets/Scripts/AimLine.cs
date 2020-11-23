using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AimLine : MonoBehaviour
{

    public Rigidbody2D theBall, theHook;
    private bool isPressed = false;
    public float releaseTime = 0.1f;
    public float maxDistance = 2f;
    public static bool canLaunch;    
    public GameObject nextBall, startScreen;
    // Start is called before the first frame update

    public GameObject trajectoryDot;
    private GameObject[] trajectoryDots;
    public int number;
        private Vector3 startPos;
    private Vector3 endPos;
    public Vector3 initPos;
    private Vector3 forceAtPlayer;
    public float forceFactor; 


    void Start()
    {
                trajectoryDots = new GameObject[number];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(isPressed == true)
        {
            if (Vector3.Distance(mousePos, theHook.position) > maxDistance)
            {
                theBall.position = theHook.position + (mousePos - theHook.position).normalized * maxDistance;
            } else {
            theBall.position = mousePos;
            }
        }

            
        

        
    }

    private void OnMouseDown()
    {
        isPressed = true;
        theBall.isKinematic = true;
                    startPos = gameObject.transform.position;
            for (int i = 0; i < number; i++)
            {
                trajectoryDots[i] = Instantiate(trajectoryDot, gameObject.transform);
            }

    }

private void OnMouseDrag()
    {

            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            //gameObject.transform.position = endPos;
            forceAtPlayer = endPos - startPos;
            for (int i = 0; i < number; i++)
            {
                trajectoryDots[i].transform.position = calculatePosition(i * 0.1f);
            }
        
        
    }
    private void OnMouseUp()
    {
        theBall.isKinematic = false;
        isPressed = false;

        if(startScreen.activeSelf == false)
        {
        for (int i = 0; i < number; i++)
           {
                Destroy(trajectoryDots[i]);
           }
                    GetComponent<AudioSource>().Play();  
                    LevelTracker.ShotCounter();
                    StartCoroutine(ReleaseBall());
        }

    }



    IEnumerator ReleaseBall ()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);
        if(nextBall != null)
        {
        nextBall.SetActive(true);
        } else {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Enemy.enemiesAlive = 0;
            LevelTracker.shotsFired = 0;
        }
    }

        private Vector2 calculatePosition(float elapsedTime) {
        return new Vector2(endPos.x, endPos.y) + //X0
                new Vector2(-forceAtPlayer.x * forceFactor, -forceAtPlayer.y * forceFactor) * elapsedTime + //ut
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime ;
    }
}

