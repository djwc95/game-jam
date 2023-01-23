using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    public int damage;
    public int dmgBuff;

    public AudioClip swing;
    AudioSource audioSource;

    float timeUntilMelee;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            other.gameObject.GetComponent<EnemyHealth>().TakeDmg(damage);
            Debug.Log("Enemy Hit");
        }
    }

    public void DmgBuff(int dmgBuff)
    {
        damage += dmgBuff;
    }
}
