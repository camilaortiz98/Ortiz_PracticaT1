using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    public float velocityRun = 15;
    public float velocityWalk = 5;
    public float jumpForce = 100;
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //constantes 
    private const int IDLE = 0;
    private const int WALK = 1;
    private const int RUN = 2;
    private const int JUMP = 3;
    private const int ATTACK = 4;
    private const int ATTACK2 = 5;

    //private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityWalk, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(WALK);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityWalk, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(WALK);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(velocityRun, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(-velocityRun, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUN);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
        }

        if (Input.GetKey(KeyCode.Z))
        {
           changeAnimation(ATTACK2);           
        }

    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
