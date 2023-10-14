using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState : MonoBehaviour
{
    public int damage;
    public float lifeSpan;
    float timer;

    public void OnHit () {
        Debug.Log("Hit");
        Destroy(gameObject);
    }

    void Update () {
        timer += Time.deltaTime;

        if (timer >= lifeSpan) OnHit();
    }


}
