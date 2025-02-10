using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float JumpForce = 300f;
    private bool isFacingRight = true;


    private bool grounded;
    private bool DoubleJump;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = -64f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 1f;

    private float timer;
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private LayerMask groundLayer;
    private Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if (grounded && !Input.GetButton("Jump"))
        {
            DoubleJump = false;
            

        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded || DoubleJump)
            {
                rb.AddForce(new Vector2(rb.velocity.x, JumpForce));
                anim.SetTrigger("jump");
                DoubleJump = !DoubleJump;
                
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
            anim.SetTrigger("dash");
        }

        timer += Time.deltaTime;
        if (timer > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("attack");
                timer = 0;
            }

            if (Input.GetMouseButtonDown(1))
            {
                anim.SetTrigger("attack");
                timer = 0;
            }

        }


        Flip();

        anim.SetBool("Move", horizontal != 0);
        anim.SetBool("grounded", grounded);
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.transform.tag == "Ground")
        {
            grounded = true;

        }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.transform.tag == "Ground")
        {
            grounded = false;

        }
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        
        yield return new WaitForSeconds(dashingTime);
        
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
