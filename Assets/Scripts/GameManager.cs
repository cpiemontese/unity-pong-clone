using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePausedUI;
    public GameObject settingsUI;
    public bool openPausedUIOnEsc = false;

    GameObject _ballInstance;

    bool _paused = false;
    public bool paused
    {
        get => _paused;
        set
        {
            _paused = value;
            Time.timeScale = _paused ? 0f : 1f;
            gamePausedUI.SetActive(_paused);
        }
    }

    public int difficulty
    {
        get
        {
            PrefsManager.PrintPrefs();
            return PrefsManager.difficulty;
        }
        set
        {
            PrefsManager.difficulty = value;
            PrefsManager.PrintPrefs();
        }
    }

    bool _settingsOpen = false;
    public bool settingsOpen
    {
        get => _settingsOpen;
        set
        {
            _settingsOpen = value;
            settingsUI.SetActive(_settingsOpen);
        }
    }

    void Awake()
    {
        Time.timeScale = 1f;
    }


    void Update()
    {
        if (openPausedUIOnEsc && Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
