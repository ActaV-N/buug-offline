using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAttackRange : MonoBehaviour
{
    private Player player;
    void Start(){
        player = transform.parent.GetComponent<Player>();
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Enemy"){
            player.handleAttackTarget(other, true);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            player.handleAttackTarget(other, true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Enemy"){
            player.handleAttackTarget(other, false);
        }
    }
}
