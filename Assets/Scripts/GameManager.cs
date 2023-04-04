using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
//using UnityEditor.VersionControl;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int tasksLeft = 2;
    public int CrewMatesLeft = 0;
    public TextMeshProUGUI TasksText;
    public TextMeshProUGUI CrewMatesLeftText;
    public GameObject GameOverPanel;
    public GameObject YouWinPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        YouWinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TasksText.text = ($"Tasks Left: {tasksLeft}");
        CrewMatesLeftText.text = ($"Crew Mates Left: {CrewMatesLeft}");

        if (tasksLeft <= 0)
        {
            GameOverPanel.SetActive(true);
        }

        if(CrewMatesLeft <= 0)
        {
            YouWinPanel.SetActive(true);
        }
    }
}
