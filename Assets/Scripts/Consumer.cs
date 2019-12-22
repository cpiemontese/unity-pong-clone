using UnityEngine;

public abstract class Consumer<T>: MonoBehaviour {
    public abstract void consume(T value);
}