using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject Menu;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ToggleMenu();
        }
    }

    public void WinGame()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCount ;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadLevel(string level) {
        SceneManager.LoadScene(level);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TogglePause(bool t_value)
    {
        Time.timeScale = t_value ? 0 : 1;
    }

    public void ToggleMenu()
    {
        bool newState = !Menu.activeSelf;
        Menu.SetActive(newState);
        TogglePause(newState);
    }
}
