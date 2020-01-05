using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalSpeed = 2f;
    public float jumpForce = 1f;

    bool isJumping = false;
     
    Rigidbody2D rb;

    public static SpriteRenderer playerGFX;

    private Vector3 _move;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerGFX = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
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
}
