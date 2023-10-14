using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int health;
    public int maxHealth;
    PlayerMovement playerMovement;
    GameState gameState;
    Rigidbody2D rb2D;

     void Awake() {
        gameState = FindObjectOfType<GameState>();
        playerMovement = GetComponent<PlayerMovement>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public bool IsAlive () {
        return health > 0;
    }

    public void TakeDamage (int damage, Collision2D col) {
        health -= damage;

        if (!IsAlive()) {OnDeath(); return;}

        Debug.Log($"Ouch! - Health {health}");

        if (col != null) {
            Vector2 localPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 dir = col.contacts[0].point - localPosition;
            dir = -dir.normalized;

            playerMovement.PushDirection(dir, 400);
        }
    }

    public void TakeHealing (int healing) {
        if (health < maxHealth) health += healing;
        Debug.Log($"You took a healing potion - Health {health}");
    }

    void OnDeath () {
        Debug.Log($"Player is dead, Game Over");
        gameState.OnGameEnd();
    }
}
