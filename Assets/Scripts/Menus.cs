using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SceneSelect(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
