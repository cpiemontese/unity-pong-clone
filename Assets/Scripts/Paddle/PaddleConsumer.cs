using UnityEngine;

public class PaddleConsumer: Consumer<Vector2> {
    public float forceFactor = 1.0f;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    override public void Consume(Vector2 force) {
        rb2d.AddForce(force * forceFactor);
    }
}