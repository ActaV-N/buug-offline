using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movePower = 1f;
    public float jumpPower = 1f;

    Rigidbody2D rigid;
    Animator animator;


    Vector3 movement;
    bool isJumping = false;




    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetInteger("Direction", -1);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetInteger("Direction", 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJumping"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            animator.SetTrigger("doJumping");
        }
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(-4, 4, 1);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(4, 4, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump()
    {
        if (!isJumping)
            return;

        rigid.velocity = Vector2.zero;

        Vector2 jumpvelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpvelocity, ForceMode2D.Impulse);

        isJumping = false;
    }
}
