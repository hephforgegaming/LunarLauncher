using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{

    public Rigidbody2D theBall, theHook;
    private bool isPressed = false;
    public float releaseTime = 0.1f;
    public float maxDistance = 2f;
    public static bool canLaunch;    public GameObject nextBall, startScreen;
    // Start is called before the first frame update
    void Start()
    {

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

    }

    private void OnMouseUp()
    {
        theBall.isKinematic = false;
        isPressed = false;
        LevelTracker.ShotCounter();
        if(startScreen.activeSelf == false)
        {
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
}
