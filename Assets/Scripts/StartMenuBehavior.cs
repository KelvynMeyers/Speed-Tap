using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuBehavior : MonoBehaviour
{
    //// VARIABLES
    public GameObject HighscoreText;

    private int highscore;
    private int timer;

    //// PRIVATE FUNCTIONS

    // Loads in timer and highscore values
    private void Start()
    {
        timer = PlayerPrefs.GetInt("Timer",10);
        highscore = PlayerPrefs.GetInt("Highscore"+timer,0);
        UpdateHighscoreText(highscore);
    }

    // Updates HighscoreText element with highscore for current timer value
    private void UpdateHighscoreText(int scoreValue)
    {
        HighscoreText.GetComponent<Text>().text = "Highscore ("+timer+"s): " + scoreValue;
    }

}
