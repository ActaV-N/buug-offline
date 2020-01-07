// Smooth towards the target

using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    public Transform[] routes;

    public GameObject target;
    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;
    Vector3 targetPosition;
    Vector3 pastTargetPosition, pastFollowerPosition;

    private bool isAttacking = false;
    private bool isDelay = false;
    private float t;

    Transform basicAttack;

    Vector3 p0, p1, p2, p3, sub;
    void Start(){
        t = 0f;
        basicAttack = routes[0];
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && !isDelay)
        {   
            if(Player.playerGFX.flipX){
                basicAttack.localScale = new Vector3(-Mathf.Abs(basicAttack.localScale.x), basicAttack.localScale.y);
                sub  = basicAttack.GetChild(0).position - targetPosition;
                p0 = targetPosition;
                p1 = basicAttack.GetChild(1).position - sub;
                p2 = basicAttack.GetChild(2).position - sub;
                p3 = basicAttack.GetChild(3).position - sub;
            }else{
                basicAttack.localScale = new Vector3(Mathf.Abs(basicAttack.localScale.x), basicAttack.localScale.y);
                sub  = basicAttack.GetChild(0).position - targetPosition;
                p0 = targetPosition;
                p1 = basicAttack.GetChild(1).position - sub;
                p2 = basicAttack.GetChild(2).position - sub;
                p3 = basicAttack.GetChild(3).position - sub;
            }
            StartCoroutine(Attack());
        }
        if(!isAttacking){
            if(Player.playerGFX.flipX)
            {
                targetPosition = (new Vector3(0.7f, 0.5f) + target.transform.position);
            }
            else
            {
                targetPosition = (new Vector3(-0.7f, 0.5f) + target.transform.position);
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        // Define a target position above and behind the target transform
        // Smoothly move the camera towards that target position
        // transform.position = SmoothApproach(pastFollowerPosition, pastTargetPosition, targetPosition, 5f);
        // pastTargetPosition = targetPosition;
        // pastFollowerPosition = transform.position;
    }

    Vector3 SmoothApproach( Vector3 pastPosition, Vector3 pastTargetPosition, Vector3 targetPosition, float speed )
    {
        float t = Time.deltaTime * speed;
        Vector3 v = ( targetPosition - pastTargetPosition ) / t;
        Vector3 f = pastPosition - pastTargetPosition + v;
        return targetPosition - v + f * Mathf.Exp( -t );
    }

    private IEnumerator Attack(){
        isAttacking = true;
        isDelay = true;

        // Vector3 interPolation = route.GetChild(0).position - (new Vector3(-0.7f, 0.5f) + target.transform.position);
        // Vector3 p0 = new Vector3(-0.7f, 0.5f) + target.transform.position;
        // Vector3 p1 = route.GetChild(1).position - interPolation;
        // Vector3 p2 = route.GetChild(2).position - interPolation;
        // Vector3 p3 = route.GetChild(3).position - interPolation;
        
        while(t<1){
            t += Time.deltaTime *3f;

            targetPosition = Mathf.Pow(1-t, 3)*p0 +  3*Mathf.Pow(1-t,2)*t*p1 + 3*Mathf.Pow(t,2)*(1-t)*p2 + Mathf.Pow(t,3)*p3;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            yield return new WaitForEndOfFrame();        
        }
        
        t=0f;
        isAttacking = false;
        yield return new WaitForSeconds(0.5f);
        isDelay = false;
    }
}