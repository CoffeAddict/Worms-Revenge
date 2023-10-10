using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int health;
    PlayerMovement playerMovement;
    Rigidbody2D rb2D;

     void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public bool isAlive () {
        return health <= 0;
    }

    public void takeDamage (int damage, Collision2D col) {
        health -= damage;
        Debug.Log($"Health {health}");

        if (col != null) {
            Vector2 localPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 dir = col.contacts[0].point - localPosition;
            dir = -dir.normalized;

            playerMovement.pushDirection(dir, 400);
        }
    }
}
