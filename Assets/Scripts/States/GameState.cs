using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool gameRunning;
    EnemyState[] enemyList;
    int enemyAmount;
    void Awake() {
        OnGameStart();
        enemyList = GetEnemies();
    }

    public void OnGameStart () {
        gameRunning = true;
    }

    public void OnGameEnd () {
        gameRunning = false;
        Debug.Log("All enemies are dead, you won!");
        Debug.Break();
    }

    public void CheckGameState () {
        enemyAmount -= 1;
        if (enemyAmount <= 0) OnGameEnd();
    }

    EnemyState[] GetEnemies () {
        EnemyState[] enemies = FindObjectsOfType<EnemyState>();
        enemyAmount = enemies.Length;
        return enemies;
    }
}
