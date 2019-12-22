﻿using UnityEngine;

public class SettingsMenuManager : MonoBehaviour
{
    SettingsStore settingsStore;

    void Start()
    {
        settingsStore = null;
        var settingsGO = GameObject.FindWithTag("Settings Store");
        if (settingsGO != null)
        {
            settingsStore = settingsGO.GetComponent<SettingsStore>();
        }
    }

    public void SetDifficulity(string difficulty)
    {
        if (settingsStore != null)
        {
            switch (difficulty)
            {
                case "Easy":
                    settingsStore.difficulty = Difficulty.Easy;
                    break;   
                case "Normal":
                    settingsStore.difficulty = Difficulty.Normal;
                    break;   
                case "Hard":
                    settingsStore.difficulty = Difficulty.Hard;
                    break;   
                default:
                    break;
            }
        }
    }
}
