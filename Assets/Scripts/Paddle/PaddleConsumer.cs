using UnityEngine;

public class PaddleConsumer: Consumer<Vector2> {
    public float forceFactor = 1.0f;

    Rigidbody2D rb2d;
/*     Vector2 newForce;
    bool shouldUpdate; */

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
/*         newForce = Vector2.zero;
        shouldUpdate = false; */
    }

    void Update()
    {
/*         if (shouldUpdate)
        {
            rb2d.AddForce(newForce);
            newForce = Vector2.zero;
        } */
    }

    override public void Consume(Vector2 force) {
/*         shouldUpdate = true;
        newForce = force; */
        rb2d.AddForce(force * forceFactor);
    }
}