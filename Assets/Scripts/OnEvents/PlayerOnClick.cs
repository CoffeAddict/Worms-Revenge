using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnClick : MonoBehaviour
{
    public GameObject bullet;
    public float rotationOffset;
    public float bulletColdDown;
    float bulleColdDownTimmer;

    void Awake() {
        bulleColdDownTimmer = bulletColdDown;
    }

    void Update () {
        bulleColdDownTimmer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && bulleColdDownTimmer >= bulletColdDown) SpawnBullet();
    }

    void SpawnBullet () {
        Vector3 targetPosition = Input.mousePosition;
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);
        targetPosition = targetPosition - transform.position;

        float angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg - rotationOffset;

        Quaternion desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Instantiate(bullet, transform.position, desiredRotation);
        bulleColdDownTimmer = 0f;
    }
}
