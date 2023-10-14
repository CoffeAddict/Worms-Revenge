using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentOnRange : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject bullet;
    public float bulletColdDown;
    float bulleColdDownTimmer;
    TurretMovement turretMovement;

    void Awake() {
        turretMovement = gameObject.GetComponentInParent<TurretMovement>();
        bulleColdDownTimmer = bulletColdDown;
    }

    void Update () {
        bulleColdDownTimmer += Time.deltaTime;

        if (turretMovement.PlayerOnRange() && bulleColdDownTimmer >= bulletColdDown) SpawnBullet();
    }

    void SpawnBullet () {
        Instantiate(bullet, transform.position, transform.rotation);
        bulleColdDownTimmer = 0f;
    }
}
