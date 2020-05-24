using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePausedUI;
    public GameObject settingsUI;
    public bool openPausedUIOnEsc = false;
    public AudioSource musicSource;
    public Toggle[] difficultyToggles;
    public Toggle musicToggle;

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
        get => PrefsManager.difficulty;
        set
        {
            _difficulty = value;
            PrefsManager.difficulty = value;
        }
    }

    [SerializeField]
    int _music = 0;
    public int music
    {
        get => PrefsManager.music;
        set
        {
            _music = 1 - _music;
            PrefsManager.music = _music;
            UpdateMusicSource();
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

    void Awake()
    {
        Time.timeScale = 1f;
        PrefsManager.PrintPrefs();
        _music = PrefsManager.music;
        _difficulty = PrefsManager.difficulty;
        UpdateMusicSource();

        if (_difficulty <= difficultyToggles.Length)
        {
            difficultyToggles[_difficulty].group.SetAllTogglesOff();
            difficultyToggles[_difficulty].isOn = true;
        }

        musicToggle.isOn = _music == 1;
    }


    void Update()
    {
        if (openPausedUIOnEsc && Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
    }

    void UpdateMusicSource()
    {
        if (musicSource)
        {
            if (_music == 1)
                musicSource.Play();
            else
                musicSource.Pause();
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
