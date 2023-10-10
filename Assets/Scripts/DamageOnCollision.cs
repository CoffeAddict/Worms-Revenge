using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageOnCollision : MonoBehaviour
{
    public int damage;
    public Component enemyHandler;
     PlayerState playerState;

     void OnCollisionEnter2D(Collision2D col) {
        GameObject colObject = col.gameObject;

        if (colObject.tag == "Player") {
            if (playerState == null) playerState = colObject.GetComponent<PlayerState>();

            playerState.takeDamage(damage, col);
        }
    }
}
