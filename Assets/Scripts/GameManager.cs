using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePausedUI;
    public GameObject settingsUI;
    public bool openPausedUIOnEsc = false;
    public AudioSource musicSource;

    [SerializeField]
    bool _paused = false;
    public bool paused
    {
        get => _paused;
        set
        {
            _paused = value;
            Time.timeScale = _paused ? 0f : 1f;
            if (gamePausedUI != null)
            {
                gamePausedUI.SetActive(_paused);
            }
        }
    }

    [SerializeField]
    int _difficulty = 0;
    public int difficulty
    {
        get
        {
            return PrefsManager.difficulty;
        }
        set
        {
            _difficulty = value;
            PrefsManager.difficulty = value;
        }
    }

    bool _settingsOpen = false;
    public bool settingsOpen
    {
        get => _settingsOpen;
        set
        {
            _settingsOpen = value;
            if (settingsUI != null)
            {
                settingsUI.SetActive(_settingsOpen);
            }
        }
    }

    bool _music = true;
    public bool music
    {
        get => _music;
        set
        {
            _music = !_music;
            if (_music)
                musicSource.Play();
            else
                musicSource.Pause();
        }
    }

    void Awake()
    {
        Time.timeScale = 1f;
        PrefsManager.difficulty = 0;
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
