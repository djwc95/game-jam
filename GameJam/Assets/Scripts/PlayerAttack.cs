using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    public int damage;
    int critDmg; 
    public int dmgBuff;

    public AudioClip swing;
    AudioSource audioSource;

    float timeUntilMelee;
    public float critChance;
    int randValue;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        critChance = 7f;
        critDmg = (damage * 2);
        randValue = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {

        while (Input.GetKey(KeyCode.LeftShift))
        {
            return;
        }
        if (timeUntilMelee <= 0f) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(swing, 0.5f);
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (randValue < critChance)
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDmg(critDmg);
                Debug.Log("Crit Hit");
            }
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDmg(damage);
                Debug.Log("Normal Hit");
            }
        }
    }

    public void DmgBuff(int dmgBuff)
    {
        damage += dmgBuff;
    }

    public void CritBuff(int critBuff)
    {
        critChance += critBuff;
    }
}
