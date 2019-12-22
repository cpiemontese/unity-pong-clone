using UnityEngine;

public class PaddleController : MonoBehaviour {
    Producer<Vector2> producer;
    Consumer<Vector2> consumer;

    void Start()
    {
        producer = GetComponent<Producer<Vector2>>();
        consumer = GetComponent<Consumer<Vector2>>();
    }

    void Update()
    {
        consumer.Consume(producer.Produce());
    }
}