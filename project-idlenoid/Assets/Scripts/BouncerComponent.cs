using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerComponent : MonoBehaviour
{
    Rigidbody2D rb;
    //TODO: Must be modifiable to achive the upgrades
    float ballSpeed = 5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * ballSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 normal = collision.contacts[0].normal;
        Vector2 vel = rb.velocity;
        // measure angle
        float angle = Vector2.Angle(vel, -normal);
        if (angle == 180)
        {

            rb.velocity = Vector2.one * (ballSpeed + 1);
        }
    }
}
