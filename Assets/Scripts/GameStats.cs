using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    //// VARIABLES
    public GameObject ScoreText;
    public GameObject TimerText;
   
    private int gameScore = 0;
    private float gameTimer = 10.0f;
    private bool gameStarted;
    private bool gameFinished;

    // TODO: Figure out if it's possible to determine game status using only a single bool statement (rather than gameStarted & gameFinished)
    // TODO: Implement a "Tap Tile to Begin" UI Element that toggles off on start
    // TODO: Implement an end-game interface depicting score, time, new high score, etc.

    //// PUBLIC FUNCTIONS
    // Function signals game start
    public void InitiateGame()
    {
        gameStarted = true;
    }

    // Function signals game halt
    public void StopGame()
    {
        gameStarted = false;
        gameFinished = true;
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
}
