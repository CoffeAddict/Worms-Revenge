using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float topSpeed;
    public float stopRate;
    Rigidbody2D rb2D;
    bool movingX;
    bool movingY;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movementhandler();
        StopHandler();
    }

    private void Movementhandler () {
        if (Input.GetAxisRaw("Horizontal") != 0) { rb2D.AddForce(new Vector2(speed * Input.GetAxisRaw("Horizontal"), 0)); }

        if (Input.GetAxisRaw("Vertical") != 0) { rb2D.AddForce(new Vector2(0, speed * Input.GetAxisRaw("Vertical"))); }

        movingX = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        movingY = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
    }

    private void StopHandler () {
        if (!movingX) rb2D.velocity = new Vector2(rb2D.velocity.x / stopRate, rb2D.velocity.y);
        if (!movingY) rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y / stopRate);

        if (rb2D.velocity.x > topSpeed) rb2D.velocity = new Vector2(topSpeed, rb2D.velocity.y);
        if (rb2D.velocity.y > topSpeed) rb2D.velocity = new Vector2(rb2D.velocity.x, topSpeed);

        if (rb2D.velocity.x < (topSpeed * -1)) rb2D.velocity = new Vector2((topSpeed * -1), rb2D.velocity.y);
        if (rb2D.velocity.y < (topSpeed * -1)) rb2D.velocity = new Vector2(rb2D.velocity.x, (topSpeed * -1));
    }
}
