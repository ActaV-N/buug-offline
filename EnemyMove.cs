using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform target;
    GameObject Player;
    Transform enemy;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var target = GameObject.FindGameObjectWithTag("Player").transform;
        var enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        var dis = Vector3.Distance(target.transform.position, enemy.transform.position);

        if(dis<=150)
        {
            if (target != null)
            {
                Vector2 dir = target.position - transform.position;

                transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
                if (dir.x >= 0)
                {
                    Vector3 scale = transform.localScale;
                    scale.x = -Mathf.Abs(scale.x);
                    transform.localScale = scale;
                }
                else
                {
                    Vector3 scale = transform.localScale;
                    scale.x = Mathf.Abs(scale.x);
                    transform.localScale = scale;
                }
            }
        }
    }
}
