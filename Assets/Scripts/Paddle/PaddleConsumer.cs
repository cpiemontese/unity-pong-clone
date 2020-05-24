using UnityEngine;

public class PaddleConsumer : Consumer<Vector2>
{
    // float _minY = -5.5f;
    // float _maxY = 5.5f;

    Rigidbody2D _rigidBody;

    void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    override public void Consume(Vector2 movement)
    {
        // transform.Translate(0f, movement.y, 0f);
        // var clampedY = Mathf.Clamp(transform.position.y, _minY, _maxY);
        // transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        _rigidBody.velocity = movement;
    }
}