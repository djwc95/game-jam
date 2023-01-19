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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    //======================= TAKE DAMAGE CALLED FORM OTHER SCRIPTS =======================
    public void TakeDmg(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
