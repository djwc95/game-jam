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
    public float flashDuration;

    public CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        dmgFlash.enabled = false;
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    //======================= TAKE DAMAGE CALLED FROM OTHER SCRIPTS =======================
    public void TakeDmg(int amount)
    {
        currentHealth -= amount;

        StartCoroutine(DamageFlash());
        StartCoroutine(cameraShake.Shaking());
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DamageFlash()
    {
        dmgFlash.enabled = true;
        yield return new WaitForSeconds(0.2f);
        dmgFlash.enabled = false;
    }
}
