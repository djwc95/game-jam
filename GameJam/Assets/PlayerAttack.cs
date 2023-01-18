using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    [SerializeField] private float damage;

    float timeUntilMelee;


    // Update is called once per frame
    void Update()
    {
        if (timeUntilMelee <= 0f) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Enemy")
            {
                //other.GetComponent<Enemy>().TakeDamage(damage);
                Debug.Log("Enemy Hit");
            }
        }
    }
}