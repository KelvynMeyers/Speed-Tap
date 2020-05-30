using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBehavior : MonoBehaviour
{
    public GameObject TimerLengthText;
    public GameObject ResetText;

    private int highscore;
    private int timer;
    private int[] timerOptions = {10,30,60};
    private int selectedTimerOption = 0;
    private int resetConfirm = 4;

    public void UpdateTimerLength()
    {
        selectedTimerOption++;
        if(selectedTimerOption >= timerOptions.Length)
        {
            selectedTimerOption = 0;
        }

        PlayerPrefs.SetInt("Timer",timerOptions[selectedTimerOption]);
        timer = PlayerPrefs.GetInt("Timer",10);
        resetConfirm = 3;
        highscore = PlayerPrefs.GetInt("Highscore"+timer,0);
        UpdateTimerLengthText(timer);
        UpdateResetText();
    }

    public void ResetHighscore()
    {
        Debug.Log(resetConfirm);
        if(resetConfirm == 4)
        {
            resetConfirm--;
            UpdateResetText(resetConfirm);
            return;
        }
        resetConfirm--;
        if(resetConfirm > 0)
        {
            UpdateResetText(resetConfirm);
            return;
        }
        PlayerPrefs.SetInt("Highscore"+timer,0);
        highscore = 0;
        resetConfirm = 3;
        UpdateResetText();
    }

    private void Start()
    {
        timer = PlayerPrefs.GetInt("Timer",10);
        highscore = PlayerPrefs.GetInt("Highscore"+timer,0);
        UpdateTimerLengthText(timer);
        UpdateResetText();
        switch(timer)
        {
            case 10: selectedTimerOption = 0; break;
            case 30: selectedTimerOption = 1; break;
            case 60: selectedTimerOption = 2; break;
            default: selectedTimerOption = 0; break;
        }
    }

    // Parameter => Warning view
    private void UpdateResetText(int confirmValue)
    {
        ResetText.GetComponent<Text>().text = "Press " + confirmValue + " times to confirm reset!";
    }

    // No parameter => Default view
    private void UpdateResetText()
    {
        ResetText.GetComponent<Text>().text = "Reset Highscore ("+timer+"s): " + highscore;
    }

    
    private void UpdateTimerLengthText(int timerValue)
    {
        TimerLengthText.GetComponent<Text>().text = "Current Timer: " + timerValue;
    }


}
