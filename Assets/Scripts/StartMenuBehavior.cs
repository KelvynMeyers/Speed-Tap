using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuBehavior : MonoBehaviour
{
    public GameObject HighscoreText;

    private int highscore;
    private int timer;

    private void Start()
    {
        timer = PlayerPrefs.GetInt("Timer",10);
        highscore = PlayerPrefs.GetInt("Highscore"+timer,0);
        UpdateHighscoreText(highscore);
    }

    private void UpdateHighscoreText(int scoreValue)
    {
        HighscoreText.GetComponent<Text>().text = "Highscore ("+timer+"s): " + scoreValue;
    }

}
