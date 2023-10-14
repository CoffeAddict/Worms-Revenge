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
        Debug.Log("Collion enter");
        GameObject colObject = col.gameObject;

        if (colObject.tag == "Enemy") {
            EnemyState enemyState = colObject.GetComponent<EnemyState>();
            enemyState.TakeDamage(bulletState.damage);
        }

        bulletState.OnHit();
    }
}
