using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    //// VARIABLES

    // Object References
    public GameObject ResultCanvas;
    public GameObject ScoreResultText;
    public GameObject TimerResultText;

    public GameObject ScoreText;
    public GameObject TimerText;
    public GameObject InstructionText;
    
   // General global use
    private int gameScore = 0;
    private float gameTimer;
    private bool gameStarted;
    private bool gameFinished;

    // Used to retrieve saved settings
    private int highscore;
    private int timer;

    //// PUBLIC FUNCTIONS
   
   // Tile pressed signals game start
    public void InitiateGame()
    {
        gameTimer = (float)timer;
        gameStarted = true;
        InstructionText.SetActive(false);
    }

    // Timer exhausted signals game halt
    public void StopGame()
    {
        gameStarted = false;
        gameFinished = true;
        AudioManager.instance.Play("TimerStop");
        UpdateScoreResultText(gameScore);
        UpdateTimerResultText();

        // Move result UI from off-camera to center screen, then activate it
        RectTransform resultCanvasRT = ResultCanvas.GetComponent<RectTransform>();
        resultCanvasRT.anchoredPosition = Vector3.zero;
        ResultCanvas.SetActive(true);

        // Possible play sound here when new highscore valid
        if(HighscoreCheck(gameScore))
        {
            Debug.Log("New highscore: "+gameScore);
        }
    }

    // Called remotely when tile is pressed, increases score value
    public void IncrementScoreValue()
    {
        if(gameFinished) return;
        if(!gameStarted) InitiateGame();
        gameScore++;
        UpdateScoreText(gameScore);  
    }

    // Says if game is still running or not
    public bool IsGameFinished()
    {
        return gameFinished;
    }

    //// PRIVATE FUNCTIONS

    // On startup, prepare for game events & remote calls
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

    // Handles timer updates per frame
    private void Update()
    {
        if(gameStarted)
        {
            gameTimer-=Time.deltaTime;
            // Begin clockdown sound
            if(gameTimer <= 5)
            {
                if(!AudioManager.instance.IsSoundPlaying("ClockTick")) AudioManager.instance.Play("ClockTick");
                // End game
                if(gameTimer <= 0)
                {
                    AudioManager.instance.Stop("ClockTick");
                    gameTimer = 0.0f;
                    StopGame();
                }
            }
            // Update timer every frame
            UpdateTimerText();
        }
    }

    // Determines if provided score is valid for new highscore
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
