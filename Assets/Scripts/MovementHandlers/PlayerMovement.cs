using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float topSpeed;
    public float stopRate;
    public bool lockMovement = false;
    Rigidbody2D rb2D;
    float movementX;
    float movementY;

    void Awake () {
        rb2D = GetComponent<Rigidbody2D>();
    }

     void Update () {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate () {
        if (!lockMovement) MovementHandler();
        VelocityHandler();
    }

     void MovementHandler () {
        if (movementX != 0) { rb2D.AddForce(new Vector2(speed * movementX, 0)); }
        if (movementY != 0) { rb2D.AddForce(new Vector2(0, speed * movementY)); }
    }

     void VelocityHandler () {
        if (movementX == 0) rb2D.velocity = new Vector2(rb2D.velocity.x / stopRate, rb2D.velocity.y);
        if (movementY == 0) rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y / stopRate);

        if (rb2D.velocity.x > topSpeed) rb2D.velocity = new Vector2(topSpeed, rb2D.velocity.y);
        if (rb2D.velocity.y > topSpeed) rb2D.velocity = new Vector2(rb2D.velocity.x, topSpeed);

        if (rb2D.velocity.x < (topSpeed * -1)) rb2D.velocity = new Vector2((topSpeed * -1), rb2D.velocity.y);
        if (rb2D.velocity.y < (topSpeed * -1)) rb2D.velocity = new Vector2(rb2D.velocity.x, (topSpeed * -1));

        if (rb2D.angularVelocity > topSpeed) rb2D.angularVelocity = topSpeed;
    }

    public void PushDirection (Vector2 vector, float force) {
        rb2D.AddForce(vector * force);
    }
}
