using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int health = 100;
    public int enemyDmg = 4;

    public PlayerHealth playerHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth.TakeDmg(enemyDmg);
        }
    }
}
