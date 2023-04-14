using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;

public class GameManager : MonoBehaviour
{
    public int tasksLeft = 2;
    public int CrewMatesLeft = 4;
    public int Hearts = 0;
    public AssetBundleLoader AssetBundleLoader;
    public TextMeshProUGUI TasksText;
    public TextMeshProUGUI CrewMatesLeftText;
    public TextMeshProUGUI HeartsLeft;
    public GameObject GameOverPanel;
    public GameObject YouWinPanel;
    public GameObject AdButtonPanel;
    public GameObject gs;
    public int wins;
    public int lose;


    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        YouWinPanel.SetActive(false);
        AdButtonPanel.SetActive(false);
        gs.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        TasksText.text = ($"Tasks Left: {tasksLeft}");
        CrewMatesLeftText.text = ($"Crew Mates Left: {CrewMatesLeft}");
        HeartsLeft.text = Hearts.ToString();

        if (tasksLeft <= 0)
        {
            GameOver();
        }

        if(CrewMatesLeft <= 0)
        {
            YouWinPanel.SetActive(true);
            wins += 1;
            gameWonEvent();
        }
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        gameLoseEvent();
        Time.timeScale = 0f;
    }

    public void lives(int amount)
    {
        if (Hearts <= 0)
        {
            AdButtonPanel.SetActive(true);
        }
        else
        {
            Hearts -= amount;
            Respawn("SkeldMap");
        }
    }

    public void PickSkin(string name)
    {
        AssetBundleLoader.LoadSprite("mat.ab", name);
        gs.SetActive(false);
    }

    public void Respawn(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }


    public void No()
    {
        AdButtonPanel.SetActive(false);
    }

    public void Addlives(int amount)
    {
        Hearts += amount;
    }


    public void gameWonEvent()
    {
        //Define Custom Parameters
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
           { "wonGameParam", wins}
        };

        // The ?levelCompleted? event will get cached locally 
        //and sent during the next scheduled upload, within 1 minute
        AnalyticsService.Instance.CustomData("wonGame", parameters);
        // You can call Events.Flush() to send the event immediately
        AnalyticsService.Instance.Flush();
    }

    public void gameLoseEvent()
    {
        //Define Custom Parameters
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
           { "loseGameParam", lose}
        };

        // The ?levelCompleted? event will get cached locally 
        //and sent during the next scheduled upload, within 1 minute
        AnalyticsService.Instance.CustomData("loseGame", parameters);
        // You can call Events.Flush() to send the event immediately
        AnalyticsService.Instance.Flush();
    }







}
