using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float health = 1f;
    public static int enemiesAlive = 0;
    public GameObject deathEffect;

    private void Start()
    {
        enemiesAlive++;
    }
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if(colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
        //Debug.Log (colInfo.relativeVelocity.magnitude);
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        enemiesAlive--;
        if(enemiesAlive >= 0)
        {
           // Debug.Log ("You win!!");
        }
        Destroy(gameObject);

    }
}
