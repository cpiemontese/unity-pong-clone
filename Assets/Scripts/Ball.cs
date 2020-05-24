using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float startingVelocityFactor;

    public void Reset()
    {
        var dir = Random.value;
        var startingDirection = 0f;
        if (dir < 0.5f)
        {
            startingDirection = -1f;
        }
        else
        {
            startingDirection = 1f;
        }
        rb2d.velocity = new Vector2(startingDirection, Random.Range(-1.0f, 1.0f)) * startingVelocityFactor;
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Reset();
    }

    void Update()
    {
        var shouldCorrect = false;
        var xCorrection = 0.0f;
        if (Mathf.Abs(rb2d.velocity.x) < startingVelocityFactor)
        {
            var sign = Mathf.Sign(rb2d.velocity.x);
            xCorrection = sign * Time.deltaTime;
            shouldCorrect = true;
        }

        var yCorrection = 0.0f;
        if (Mathf.Abs(rb2d.velocity.y) < Mathf.Epsilon)
        {
            var sign = Mathf.Sign(rb2d.velocity.y);
            yCorrection = sign * Time.deltaTime;
            shouldCorrect = true;
        }

        if (shouldCorrect)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x + xCorrection, rb2d.velocity.y + yCorrection);
        }
    }
}
