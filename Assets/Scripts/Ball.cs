using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float startingVelocityFactor;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        var dir = Random.value;
        var startingDirection = 0f;
        if (dir < 0.5f)
        {
            startingDirection = -1f;
        } else
        {
            startingDirection = 1f;
        }
        rb2d.velocity = new Vector2(startingDirection, Random.Range(-1.0f, 1.0f)) * startingVelocityFactor;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb2d.velocity.x) < startingVelocityFactor)
        {
            var sign = Mathf.Sign(rb2d.velocity.x);
            rb2d.velocity = new Vector2(rb2d.velocity.x + sign*Time.deltaTime, rb2d.velocity.y);
        }
    }
}
