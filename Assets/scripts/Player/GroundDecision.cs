using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDecision : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ground"){
            player.handleGroundDecision(other, true);
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Ground"){
            player.handleGroundDecision(other, true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Ground"){
            player.handleGroundDecision(other, false);
        }
    }
}
