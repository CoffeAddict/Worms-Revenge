using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationOffset;
    public float rangeOfView;
    PlayerState player;
    float distanceToPlayer;
    Vector3 lastPlayerPosition;

    Rigidbody2D rb2D;

    void Awake () {
        rb2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerState>();
    }

    void FixedUpdate () {
        if (player != null) {
            if (PlayerOnRange() == true) {
                lastPlayerPosition = player.transform.position;
            }

            LookAtPlayer();
        }
    }

    void LookAtPlayer() {
        if (lastPlayerPosition == null) return;

        Vector3 targetPosition = lastPlayerPosition - transform.position;

        float angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg - rotationOffset;

        Quaternion desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }

    public bool PlayerOnRange () {
        distanceToPlayer = Vector3.Distance (player.transform.position, transform.position);
        return distanceToPlayer <= rangeOfView;
    }
}
