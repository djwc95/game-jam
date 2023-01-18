using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public int maxHealth;
    public int currentHealth;
    public bool vulnerable;

    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        vulnerable = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2 (moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveSpeed = (moveSpeed * 1.75f);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }
}
