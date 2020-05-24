using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string optionsMenuName = "Options Menu";

    public delegate void OnEscapePress();
    public static event OnEscapePress onEscapePress;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RaiseOnEscapePress();
            SceneManager.LoadScene(optionsMenuName);
        }
    }

    public void RaiseOnEscapePress()
    {
        if (onEscapePress != null)
        {
            onEscapePress();
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }
}
