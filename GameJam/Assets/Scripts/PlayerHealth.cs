using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public bool vulnerable;
    public Text healthText;
    public Image dmgFlash;
    public int armor;

    public CameraShake cameraShake;
    public PlayerBehaviour playerBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        dmgFlash.enabled = false;
        currentHealth = maxHealth;
        armor = 0;
    }

    void Update()
    {
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString(); //update our hp counter in UI canvas
    }

    public void OnCollisionEnter2D(Collision2D collsion)
    {
        if (armor >= 1) // if we have armor, lose one until we are out
        {
            armor -= 1;
            return;
        }
        else if (armor == 0) // if no armor, take dmg
        {
            if (collsion.gameObject.tag == "Enemy")
            {
                TakeDmg(4);
            }
        }
    }

    //======================= TAKE DAMAGE CALLED FROM OTHER SCRIPTS =======================
    public void TakeDmg(int amount)
    {
        while (Input.GetKey(KeyCode.LeftShift)) // negate dmg while blocking
        {
            return;
        }
        currentHealth -= amount; // take dmg

        StartCoroutine(DamageFlash()); //player feedback
        StartCoroutine(cameraShake.Shaking()); //player feedback

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // kill us if we run out of health
        }
    }

    IEnumerator DamageFlash() //player feedback
    {
        dmgFlash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        dmgFlash.enabled = false;
        yield return new WaitForSeconds(0.1f);
        dmgFlash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        dmgFlash.enabled = false;
    }

    //========================== BUFFS WE CAN BUY IN SHOP ==============================
    public void ArmorBuff(int amount)
    {
        armor += amount;
    }
}
