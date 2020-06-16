using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBehavior : MonoBehaviour
{
    //// VARIABLES

    // Object Resources
    public GameObject TimerLengthText;
    public GameObject ResetText;

    // General Function Use
    private int highscore;
    private int timer;
    private int[] timerOptions = {10,30,60};
    private int selectedTimerOption = 0;
    private int maxConfirmations = 4;
    private int resetConfirm = 4;

    //// PUBLIC FUNCTIONS

    // Cycles through timer options, updating all references to timer (text included)
    public void UpdateTimerLength()
    {
        // Increments through options, looping back to start if necessary
        selectedTimerOption++;
        if(selectedTimerOption >= timerOptions.Length)
        {
            selectedTimerOption = 0;
        }

        PlayerPrefs.SetInt("Timer",timerOptions[selectedTimerOption]);
        timer = PlayerPrefs.GetInt("Timer",10);
        resetConfirm = maxConfirmations;
        highscore = PlayerPrefs.GetInt("Highscore"+timer,0);
        UpdateTimerLengthText(timer);
        UpdateResetText();
    }

    // Button press yields confirmation a globally specified number of times before resetting high score for given timer value
    public void ResetHighscore()
    {
        // Pre-confirmation text
        if(resetConfirm == maxConfirmations)
        {
            resetConfirm--;
            UpdateResetText(resetConfirm);
            return;
        }
        resetConfirm--;
        // Confirmation text cycle
        if(resetConfirm > 0)
        {
            UpdateResetText(resetConfirm);
            return;
        }
        // Post-confirmation text
        PlayerPrefs.SetInt("Highscore"+timer,0);
        highscore = 0;
        resetConfirm = maxConfirmations;
        UpdateResetText();
    }

    //// PRIVATE FUNCTIONS

    // Prepares scene for setting alterations
    private void Start()
    {
        timer = PlayerPrefs.GetInt("Timer",10);
        highscore = PlayerPrefs.GetInt("Highscore"+timer,0);
        UpdateTimerLengthText(timer);
        UpdateResetText();
        // Updates set-timer value (for timer alteration and highscore text) based on loaded in timer
        switch(timer)
        {
            case 10: selectedTimerOption = 0; break;
            case 30: selectedTimerOption = 1; break;
            case 60: selectedTimerOption = 2; break;
            default: selectedTimerOption = 0; break;
        }
    }

    // Updates ResetText element with confirmation warning text
    // Provided parameter => Warning view
    private void UpdateResetText(int confirmValue)
    {
        ResetText.GetComponent<Text>().text = "Press " + confirmValue + " times to confirm!";
    }

    // Updates ResetText element with default highscore reset text
    // No parameter => Default view
    private void UpdateResetText()
    {
        ResetText.GetComponent<Text>().text = "Reset Highscore ("+timer+"s): " + highscore;
    }

    // Updates TimerLengthText element
    private void UpdateTimerLengthText(int timerValue)
    {
        TimerLengthText.GetComponent<Text>().text = "Current Timer: " + timerValue;
    }


}
