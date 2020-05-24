using UnityEngine;

public class PaddleHumanProducer : Producer<Vector2>
{
    public float movementSpeed = 10.0f;

    public override Vector2 Produce()
    {
        var vx = Input.GetAxis("Vertical");
        return new Vector2(0f, vx * movementSpeed);
    }
}