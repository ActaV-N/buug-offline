using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CretureTrace : MonoBehaviour
{
    Transform target;
    Transform enemy;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        target = Gameobject.FindGmaeObjectWithTag("Player").transform;  
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector2 dir = target.position - transform.position;

            transform.position += (target.position = transform.position).normalized * speed * Time.deltaTime;
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
