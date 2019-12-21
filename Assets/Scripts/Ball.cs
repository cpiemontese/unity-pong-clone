using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startingVelocityFactor;

    void Awake()
    {
        var rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-1.0f, 1.0f)) * startingVelocityFactor;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
