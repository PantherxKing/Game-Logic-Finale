using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void SceneSelect(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
