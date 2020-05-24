using UnityEngine;
using UnityEngine.SceneManagement;

public static class PrefsManager
{
    public static int difficulty
    {
        get => PlayerPrefs.GetInt("Difficulty", 0);
        set
        {
            PlayerPrefs.SetInt("Difficulty", value);
        }
    }

    public static int music
    {
        get => PlayerPrefs.GetInt("Music", 1);
        set
        {
            PlayerPrefs.SetInt("Music", value);
        }
    }

    public static void PrintPrefs()
    {
        string[] values = { "Difficulty", "Music" };

        foreach (string value in values)
        {
            if (PlayerPrefs.HasKey(value))
            {
                Debug.Log($"{value}: { PlayerPrefs.GetInt(value, 0)}");
            }
            else
            {
                Debug.Log($"{value} is not set");
            }
        }
    }
}
