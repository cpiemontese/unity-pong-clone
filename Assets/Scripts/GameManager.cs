using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject gamePausedUI;

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

    void Awake()
    {
        _ballInstance = Instantiate(ballPrefab);
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
        }
    }

    public void Reset()
    {
        Destroy(_ballInstance);
        _ballInstance = Instantiate(ballPrefab);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
