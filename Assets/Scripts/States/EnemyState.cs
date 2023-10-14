using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public int health;
    GameState gameState;

    void Awake () {
        gameState = FindObjectOfType<GameState>();
    }

    void OnDeath () {
        gameState.CheckGameState();
        Destroy(gameObject);
    }

    public void TakeDamage (int damage) {
        health -= damage;
        if (health <= 0) OnDeath();
    }
}
