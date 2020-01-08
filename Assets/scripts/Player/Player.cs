using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalSpeed = 2f;
    public float jumpForce = 1f;

    bool isJumping = false, canJump = false;
    
    Rigidbody2D rb;

    public static SpriteRenderer playerGFX;
    public static Transform AttackTarget;

    private Vector3 _move;

    Animator animator;
    Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerGFX = gameObject.GetComponentInChildren<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(canJump){
                isJumping = true;
            }
        }

        // Set move animation
        if(_move != Vector3.zero){
            animator.SetBool("IsRunning", true);
        } else{
            animator.SetBool("IsRunning", false);
        }

        // Set jump animation
        Vector3 curVel = (transform.position - prevPos) / Time.deltaTime;
        if(curVel.y > 0){
            animator.SetBool("IsJumping", true);
            // Debug.Log("Up");
        } else{
            animator.SetBool("IsJumping", false);
            // Debug.Log("Down");
        }
        prevPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerGFX.flipX = false;

            _move = Vector3.right * horizontalSpeed;
            transform.Translate(_move * Time.deltaTime);
        }
        else if(_move.sqrMagnitude > 0f)
        {
            _move *= 0.5f;
            transform.Translate(_move * Time.deltaTime);
            if (_move.magnitude < 0.001f) _move = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerGFX.flipX = true;

            _move = Vector3.left * horizontalSpeed;
            transform.Translate(_move * Time.deltaTime);
        }
        else if (_move.sqrMagnitude > 0f)
        {
            _move *= 0.5f;
            transform.Translate(_move * Time.deltaTime);
            if (_move.magnitude < 0.001f) _move = Vector3.zero;
        }
    }

    void Jump()
    {
        if (!isJumping) return;

        rb.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpForce);
        rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }
    
    public void handleAttackTarget(Collider2D other, bool type){
        if(type) AttackTarget = other.transform;
        else AttackTarget = null;
    }

    public void handleGroundDecision(Collider2D other, bool type){
        if(type){
            animator.SetBool("OnAir", false);
            canJump = true;
        } else{
            animator.SetBool("OnAir", true);
            canJump = false;
        }
    }
}
