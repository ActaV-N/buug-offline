// Smooth towards the target

using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour
{
    public GameObject target;
    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;
    Vector3 targetPosition;

    void Update()
    {
        // Define a target position above and behind the target transform
        if(Player.playerGFX.flipX)
        {
            targetPosition = (new Vector3(0.7f, 0.5f) + target.transform.position);

        }
        else
        {
            targetPosition = (new Vector3(-0.7f, 0.5f) + target.transform.position);
        }
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}