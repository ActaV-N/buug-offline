using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Linear attack
    // Groun attack
    // Drop attack
    string pattern = "Linear"; // default attack pattern(Linear attack)

    // None
    // Fire
    // Ice
    // Thunder
    string attribute = "none";


    public GameObject weapon;

    public float horizontalSpeed = 1f;
    public float jumpForce = 1f;

    bool isAttack = false;
     
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        weapon.transform.position = transform.position + new Vector3(-1, 1);
        if(Input.GetAxis("Horizontal") < 0)
        {
            if (!isAttack)
            {
                weapon.transform.position = transform.position + new Vector3(0.3f, 0.3f);
            }
            transform.position += new Vector3(-horizontalSpeed * Time.deltaTime, 0);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            if (!isAttack)
            {
                weapon.transform.position = transform.position + new Vector3(-0.3f, 0.3f);
            }
            transform.position += new Vector3(horizontalSpeed * Time.deltaTime, 0);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            print("fire");
        }
    }
}
