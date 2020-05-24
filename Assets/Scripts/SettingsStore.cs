using UnityEngine;

public class SettingsStore : MonoBehaviour
{
    public Difficulty difficulty = Difficulty.Normal;

    public Transform ballTransform;
    public Transform playerTransform;
    public Transform aiTransform;

    public Vector2 ballDirection;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
