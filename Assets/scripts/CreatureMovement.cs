using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour {

    public float movePower = 1f;

    Animator animator;
    Vector3 movement;
    SpriteRenderer renderer;
    int movementFlag = 0;



	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine("ChangeMovement");
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
}
