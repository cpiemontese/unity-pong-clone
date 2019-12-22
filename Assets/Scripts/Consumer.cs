using UnityEngine;

public abstract class Consumer<T>: MonoBehaviour {
    public abstract void Consume(T value);
}