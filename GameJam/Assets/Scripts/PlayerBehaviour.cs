using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 moveInput;
    bool facingRight = true;

    [SerializeField] float dashLength = 1f;
    [SerializeField] float dashSpeed = 5f;
    float activeMoveSpeed;
    public float dashCooldown;

    float dashCounter;
    float dashCoolCounter;

    Renderer render;
    Color color;

    // ==================== SETTING EVERYTHING UP ==========================
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        render = GetComponent<Renderer>();
        color = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // ===================== MOVEMENT STUFF ======================
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        rb.velocity = moveInput * activeMoveSpeed;

        // ====================== DASH MECHANIC (SPACE TO DASH) =====================
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCooldown <=0 && dashCounter <= 0)
            {
                //==================== SETS MOVE SPEED TO DASH SPEED FOR X SECONDS ==========
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

                //======================== GAIN TEMP INVINCIBILITY ====================
                color.a = 0.5f;
                render.material.color = color;
                Physics2D.IgnoreLayerCollision(6, 8, true);
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;

                //================== LOSE INVINCIBILITY =========================
                Physics2D.IgnoreLayerCollision(6, 8, false);
                color.a = 1f;
                render.material.color = color;
            }
        }
        //================= HOW LONG TILL WE CAN DASH AGAIN =====================
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // ================== FLIPPING SPRITE DIRECTION BASED ON INPUT =============================
        if (moveInput.x > 0 && !facingRight)
        {
            Flip();
        }

        if (moveInput.x < 0 && facingRight)
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
}
