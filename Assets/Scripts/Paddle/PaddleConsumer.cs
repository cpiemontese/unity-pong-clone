using UnityEngine;

public class PaddleConsumer: Consumer<Vector2> {
    float minY = -5.5f;
    float maxY = 5.5f;

    override public void Consume(Vector2 movement) {
        transform.Translate(movement.x, movement.y, 0f);
        var clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}