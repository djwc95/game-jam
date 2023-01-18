using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 moveDirection;
    bool facingRight = true;

    // ==================== SETTING EVERYTHING UP ==========================
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ===================== MOVEMENT STUFF ======================
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2 (moveX, moveY).normalized;

        // ====================== DASH MECHANIC (SPACE TO DASH) =====================
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveSpeed = (moveSpeed * 1.75f);
        }
    }

    void FixedUpdate()
    {
        //============================= MVMT CALCULATION ==========================
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // ================== FLIPPING SPRITE DIRECTION BASED ON INPUT =============================
        if (moveDirection.x > 0 && !facingRight)
        {
            Flip();
        }

        if (moveDirection.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    // ==================== TAKE DMG ON IMPACT WITH ENEMY =============================
}
