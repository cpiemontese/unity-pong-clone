using UnityEngine;

public class SettingsStore : MonoBehaviour
{
    public Difficulty difficulty = Difficulty.Normal;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
