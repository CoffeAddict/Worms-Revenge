using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOnCollision : MonoBehaviour
{
    public int healing;
    public ItemState itemHandler;
    PlayerState playerState;

     void OnTriggerEnter2D(Collider2D col) {
        GameObject colObject = col.gameObject;

        if (colObject.tag == "Player") {
            if (playerState == null) playerState = colObject.GetComponent<PlayerState>();

            playerState.TakeHealing(healing);

            itemHandler.OnPlayerInteraction();
        }
    }
}