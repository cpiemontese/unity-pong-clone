using UnityEngine;

public class PaddleHumanProducer : Producer<Vector2> {
    void Start()
    {
    }

    void Update()
    {
    }

    public override Vector2 Produce() {
        var vertical = Input.GetAxis("Vertical");
        var newValue = Vector2.zero;
        if (vertical > 0.0f)
        {
            newValue = Vector2.up;
        } else if (vertical < 0.0f)
        {
            newValue = Vector2.down;
        }
        return newValue;
    }
}