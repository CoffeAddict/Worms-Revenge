using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool gameRunning;
    private void Awake() {
        OnGameStart();
    }

    public void OnGameStart () {
        gameRunning = true;
    }

    public void OnGameEnd () {
        gameRunning = false;
        Debug.Break();
    }
}
