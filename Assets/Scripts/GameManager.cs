using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePausedUI;
    public GameObject settingsUI;
    public MusicPlayer musicPlayer;
    public bool openPausedUIOnEsc = false;
    public Toggle[] difficultyToggles;
    public Toggle musicToggle;
    public int winningScore = 10;

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
            UpdateMusicPlayer();
        }
    }

    [SerializeField]
    int playerScore = 0;
    [SerializeField]
    int aiScore = 0;

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
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayer>();

        Time.timeScale = 1f;
        PrefsManager.PrintPrefs();
        _music = PrefsManager.music;
        _difficulty = PrefsManager.difficulty;
        UpdateMusicPlayer();

        if (_difficulty < difficultyToggles.Length)
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

    void UpdateMusicPlayer()
    {
        if (musicPlayer != null)
        {
            if (_music == 1)
                musicPlayer.PlayMusic();
            else
                musicPlayer.PauseMusic();
        }
    }

    public void ScorePlayer()
    {
        playerScore++;

        if (playerScore >= winningScore)
        {
            LoadScene("PlayerWin");
        }
    }

    public void ScoreAI()
    {
        aiScore++;

        if (aiScore >= winningScore)
        {
            LoadScene("AIWin");
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
