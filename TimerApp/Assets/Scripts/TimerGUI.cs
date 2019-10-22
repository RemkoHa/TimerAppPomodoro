using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerGUI : MonoBehaviour {

    [Header("GUI")]
    public Text timerText;
    public TimerScript timeScript;
    public Text PomCount;

    [Header("Images")]
    public Sprite[] AllTomatoesImages;
    public Image TomatoesImageHolder;

	// Use this for initialization
	void Start () {
        timerText.text = "Work Time Left :  " + timeScript.timerStartValue;
        TomatoesImageHolder.sprite = AllTomatoesImages[(int)Mathf.Abs(UnityEngine.Random.Range(0, AllTomatoesImages.Length))];
    }

    public void ChangeImage()
    {
        TomatoesImageHolder.sprite = AllTomatoesImages[(int)Mathf.Abs(UnityEngine.Random.Range(0, AllTomatoesImages.Length))];
    }
	
	// Update is called once per frame
	void Update () {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeScript.timeLeft);
        string timeText = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        if (timeScript.PomodoroTimerEnabled)
        {
            timerText.text = "Work Time Left :  " + timeText;
        }
        if (timeScript.RelaxTimerEnabled)
        {
            timerText.text = "Relax Time Left : " + timeText;
        }
        if(!timeScript.RelaxTimerEnabled && !timeScript.PomodoroTimerEnabled)
        {
            timerText.text = "Click Start To Begin Work Session";
        }
        PomCount.text = "Pomodoro's Session : " + timeScript.SessionPoms + "\n Old Pomodoro's : " + timeScript.OldPoms + "\n Total Pomodoro : " + timeScript.TotalPoms;

        
    }
}
