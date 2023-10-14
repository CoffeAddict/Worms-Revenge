using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState : MonoBehaviour
{
    public int damage;
    public float lifeSpan;
    public bool damagePlayer;
    float lifeSpanTimer;

    public void OnHit () {
        Destroy(gameObject);
    }

    void Update () {
        lifeSpanTimer += Time.deltaTime;

        if (lifeSpanTimer >= lifeSpan) OnHit();
    }


}
