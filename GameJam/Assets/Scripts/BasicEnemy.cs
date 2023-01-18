using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int health = 100;
    public int enemyDmg = 4;

    public PlayerHealth playerHealth;

    //public void TakeDmg(int damage)
    //{
        //health -= damage;

        //if (health <= 0)
        //{
            //Destroy(gameObject);
            //Debug.Log("enemy died");
        //}
    //}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth.TakeDmg(enemyDmg);
        }
    }
}
