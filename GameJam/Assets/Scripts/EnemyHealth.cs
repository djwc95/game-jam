using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject floatingDmg;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDmg(int amount)
    {
        currentHealth -= amount;
        GameObject dmgGiven = Instantiate(floatingDmg, transform.position, Quaternion.identity) as GameObject;
        dmgGiven.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
