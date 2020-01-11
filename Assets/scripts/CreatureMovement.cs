using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour {

    public float movePower = 1f;


    Animator animator;
    Vector3 movement;
    SpriteRenderer renderer;
    Rigidbody2D rb;
    int movementFlag = 0;
    Vector3 playerGFX;
    GameObject player;
    Vector3 prevpos;


    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine("ChangeMovement");
        player = GameObject.Find("Player");
        
	}

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);

        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }

    void Update(){
        if(movement == Vector3.zero){
            animator.SetBool("isMoving",false);
        } else{
            animator.SetBool("isMoving",true);
        }
        playerGFX = player.transform.position;
        prevpos = transform.position;
    }

	void FixedUpdate () {
        Move();
	}

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            renderer.flipX = false;
        }
        else if(movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            renderer.flipX = true;
        }
        movement = moveVelocity * movePower * Time.deltaTime;
        transform.position += movement;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackPoint")
        {

            Ondamaged(collision.transform.position);
        }
    }

    void Ondamaged(Vector2 targetpos)
    {
        renderer.color = new Color(1, 1, 1, 0.4f);

        int dirc;
        if (playerGFX.x > prevpos.x)
            dirc = -1;
        else
            dirc = 1;
        rb.AddForce(new Vector2(dirc, 1) * 3, ForceMode2D.Impulse);

        Invoke("OffDamaged", 1);
    }

    void OffDamaged()
    {
        renderer.color = new Color(1,1,1,1);
    }

}
