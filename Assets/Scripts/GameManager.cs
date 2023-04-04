using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
//using UnityEditor.VersionControl;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int tasksLeft = 2;
    public int CrewMatesLeft = 4;
    public int Hearts = 0;
    public TextMeshProUGUI TasksText;
    public TextMeshProUGUI CrewMatesLeftText;
    public TextMeshProUGUI HeartsLeft;
    public GameObject GameOverPanel;
    public GameObject YouWinPanel;
    public GameObject AdButtonPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        YouWinPanel.SetActive(false);
        AdButtonPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TasksText.text = ($"Tasks Left: {tasksLeft}");
        CrewMatesLeftText.text = ($"Crew Mates Left: {CrewMatesLeft}");
        HeartsLeft.text = Hearts.ToString();

        if (tasksLeft <= 0)
        {
            GameOverPanel.SetActive(true);
        }

        if(CrewMatesLeft <= 0)
        {
            YouWinPanel.SetActive(true);
        }
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
        }
    }

    public void No()
    {
        AdButtonPanel.SetActive(false);
    }

    public void Addlives(int amount)
    {
        Hearts += amount;
    }
}
