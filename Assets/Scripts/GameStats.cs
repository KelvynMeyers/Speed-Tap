using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    //// VARIABLES
    public GameObject ResultCanvas;
    public GameObject ScoreResultText;
    public GameObject TimerResultText;

    public GameObject ScoreText;
    public GameObject TimerText;
    public GameObject InstructionText;
    
   
    private int gameScore = 0;
    private float gameTimer;
    private bool gameStarted;
    private bool gameFinished;

    private int highscore;
    private int timer;

    // TODO: Audio
    // TODO: Volume adjustment

    //// PUBLIC FUNCTIONS
    // Function signals game start
    public void InitiateGame()
    {
        gameTimer = (float)timer;
        gameStarted = true;
        InstructionText.SetActive(false);
    }

    // Function signals game halt
    public void StopGame()
    {
        gameStarted = false;
        gameFinished = true;
        UpdateScoreResultText(gameScore);
        UpdateTimerResultText();
        ResultCanvas.SetActive(true);
        if(HighscoreCheck(gameScore))
        {
            Debug.Log("New highscore: "+gameScore);
        }
    }

    // Function increases score value, called remotely when tile is pressed
    public void IncrementScoreValue()
    {
        if(gameFinished)
        {
            return;
        }
        if(!gameStarted)
        {
            InitiateGame();
        }
        gameScore++;
        UpdateScoreText(gameScore);  
    }

    // Function returns true or false depending on if game is finished
    public bool IsGameFinished()
    {
        return gameFinished;
    }

    //// PRIVATE FUNCTIONS
    // Function begins on startup
    private void Start()
    {
        gameStarted = false;
        gameFinished = false;
        ResultCanvas.SetActive(false);
        timer = PlayerPrefs.GetInt("Timer",10);
        highscore = PlayerPrefs.GetInt("Highscore"+timer,0);
        UpdateTimerText();
        UpdateScoreText(0);
    }

    // Function runs every frame
    private void Update()
    {
        if(gameStarted)
        {
            gameTimer-=Time.deltaTime;

            if(gameTimer <= 0)
            {
                gameTimer = 0.0f;
                StopGame();
            }

            UpdateTimerText();
        }
    }

    private bool HighscoreCheck(int newScore)
    {
        if(newScore > highscore)
        {
            PlayerPrefs.SetInt("Highscore"+timer,newScore);
            highscore = newScore;
            return true;
        }
        return false;
    }

    // Function updates text for Score UI Element
    private void UpdateScoreText(int scoreValue)
    {
        ScoreText.GetComponent<Text>().text = "Score: " + scoreValue;
    }

    // Function updates text for Timer UI Element
    private void UpdateTimerText()
    { 
        TimerText.GetComponent<Text>().text = "Timer: " + gameTimer.ToString("00.00");
    }

    // Function updates text for Score Result UI Element
    private void UpdateScoreResultText(int scoreValue)
    {
        ScoreResultText.GetComponent<Text>().text = "SCORE: " + scoreValue;
    }

    // Function updates text for Timer Result UI Element
    private void UpdateTimerResultText()
    { 
        TimerResultText.GetComponent<Text>().text = "TIMER: " + timer.ToString("00.00");
    }
}
