using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour {

    public float movePower = 1f; //움직임 속도
    public int nextMove; //움직임 속도
    public int hp = 3; // 몬스터 체력
    int movementFlag = 0; //몬스터 종류(아직은 한개뿐)

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Animator animator;
    Vector3 movement;
    GameObject traceTarget;

    bool isTracing;
    bool isRunning;
    




    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        rigid = gameObject.GetComponentInChildren<Rigidbody2D>();

        StartCoroutine("ChangeMovement");
	}

    IEnumerator ChangeMovement() //코루틴 저장해서 특정행동을 하도록만듬
    {
        movementFlag = Random.Range(0, 3);

        if (movementFlag == 0)
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);

        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        Attack();
	}

    private void Update()
    {
        if(hp <=0)
        {
            SpawnManager._instance.enemyCount--;
            SpawnManager._instance.isSpawn[int.Parse(transform.parent.name)-1] = false;
            Destroy(this.gameObject);
        }
    }

    void Move() // 움직임 구현
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if(isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x) 
                dist = "Right";
        }

        else
        {
            if (movementFlag == 1)
                dist = "Left";
            else if (movementFlag == 2) 
                dist = "Right";
        }

        if(dist =="Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(dist=="Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

        /*if(movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if(movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-2, 2, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;*/
    }

    void OnTriggerEnter2D(Collider2D other)//범위내 player가 없을때 코루틴 적용
    {
        if(other.gameObject.tag=="Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChansgeMovement");
        }
    }

    void OnTriggerStay2D(Collider2D other)// 범위내 player있을때 코루틴 스탑후 tracing 활성화
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
            animator.SetBool("isMoving", true);
        }
    }

    void OnteriggerExit2D(Collider2D other)// 범위에서 사라지면 코루틴 다시 활성화
    {
        if(other.gameObject.tag=="Player")
        {
            isTracing = false;

            StartCoroutine("ChangeMovement");
        }
    }

    void Attack()
    {

    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attacker")
        {
            OnDamaged(collision.transform.position);
            hp--;
            if (hp <= 0)
            {
                SpawnManager._instance.enemyCount--;
                SpawnManager._instance.isSpawn[int.Parse(transform.parent.name) - 1] = false;
                Destroy(this.gameObject);
            }
        }
    }

    
    void OnDamaged(Vector2 targetPos)//맞고나서
    {
        //맞아서 투명해졌어요
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //맞고나서 튕겨저나가는거지
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1)*7, ForceMode2D.Impulse);

        //시간 텀을 위해서
        Invoke("OffDamage", 0.8f);
    }

    void OffDamage()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
