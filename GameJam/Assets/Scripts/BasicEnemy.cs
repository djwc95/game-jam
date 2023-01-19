using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public int health = 100;
    public int enemyDmg = 4;
    public Image dmgFlash;
    public float flashDuration;

    public PlayerHealth playerHealth;

    public void OnCollisionEnter2D(Collision2D collsion)
    {
        if (collsion.gameObject.tag == "Player")
        {
            playerHealth.TakeDmg(enemyDmg);
            
        }
    }
}
