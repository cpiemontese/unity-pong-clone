using UnityEngine;

public abstract class Producer<T> : MonoBehaviour
{
    public abstract T Produce();
}