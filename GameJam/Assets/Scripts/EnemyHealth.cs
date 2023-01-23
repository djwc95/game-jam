using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject floatingDmg;

    public SpriteRenderer rend;
    public AudioClip clink;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDmg(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(FlashRed());
        audioSource.PlayOneShot(clink, 0.5f);
        GameObject dmgGiven = Instantiate(floatingDmg, transform.position, Quaternion.identity) as GameObject;
        dmgGiven.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString();
        if (currentHealth <= 0)
        {
            audioSource.PlayOneShot(clink, 0.5f);
            Destroy(gameObject);
        }
    }

    public IEnumerator FlashRed()
    {
        rend.color = Color.red;
        yield return new WaitForSeconds(.15f);
        rend.color = Color.white;
    }
}
