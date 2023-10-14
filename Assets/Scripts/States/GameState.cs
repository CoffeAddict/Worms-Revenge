using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool gameRunning;
    EnemyState[] enemyList;
    void Awake() {
        OnGameStart();
        enemyList = GetEnemies();
    }

    public void OnGameStart () {
        gameRunning = true;
    }

    public void OnGameEnd () {
        gameRunning = false;
        Debug.Break();
    }

    public void CheckGameState () {
        Debug.Log(enemyList.Length);
    }

    EnemyState[] GetEnemies () {
        return FindObjectsOfType<EnemyState>();
    }
}
