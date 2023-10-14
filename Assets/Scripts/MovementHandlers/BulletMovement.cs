using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb2D;

    void Awake () {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        MoveForward();
    }

    void MoveForward() {
        rb2D.AddForce(new Vector2(0, speed));
    }
}
