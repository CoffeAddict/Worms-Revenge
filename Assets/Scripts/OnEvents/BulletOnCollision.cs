using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOnCollision : MonoBehaviour
{
    Component enemyHandler;
    BulletState bulletState;

    void Awake() {
        bulletState = gameObject.GetComponent<BulletState>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        GameObject colObject = col.gameObject;

        if (!bulletState.damagePlayer && colObject.tag == "Enemy") {
            EnemyState enemyState = colObject.GetComponent<EnemyState>();
            if (enemyState != null) enemyState.TakeDamage(bulletState.damage);

            bulletState.OnHit();
        }

        if (bulletState.damagePlayer && colObject.tag == "Player") {
            PlayerState playerState = colObject.GetComponent<PlayerState>();
            if (playerState != null) playerState.TakeDamage(bulletState.damage);

            bulletState.OnHit();
        }

    }
}
