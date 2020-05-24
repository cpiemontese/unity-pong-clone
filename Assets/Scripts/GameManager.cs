using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePausedUI;
    public GameObject settingsUI;

    GameObject _ballInstance;

    bool _paused = false;
    public bool paused {
        get => _paused;
        set {
            _paused = value;
            Time.timeScale = _paused ? 0f : 1f;
            gamePausedUI.SetActive(_paused);
        }
    }

    bool _settingsOpen = false;
    public bool settingsOpen {
        get => _settingsOpen;
        set {
            _settingsOpen = value;
            settingsUI.SetActive(_settingsOpen);
        }
    }

    void Awake()
    {
        Time.timeScale = 1f;
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
        }
    }

    public void Reset()
    {
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
