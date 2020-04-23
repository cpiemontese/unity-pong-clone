using UnityEngine;

public class PaddleHumanProducer : Producer<Vector2> {
    public float forceFactor = 10.0f;

    void Start()
    {
    }

    void Update()
    {
    }

    public override Vector2 Produce() {
        var vertical = Input.GetAxis("Vertical");
        return Vector2.up * vertical * forceFactor * Time.deltaTime;
    }
}