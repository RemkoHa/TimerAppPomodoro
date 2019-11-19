using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour {

    [Header("Timer Values")]
    public float timeLeft = 0;
    public float relaxTime = 0;
    public float workTime = 0;
    public int timerStartValue = 0;


    public bool PomodoroTimerEnabled = false;
    public bool RelaxTimerEnabled = false;


    [Header("Audio")]
    public AudioClip EndWorkTimer;
    public AudioClip EndRelaxTimer;
    public AudioSource Asource;

    [Header("GUI")]
    public GameObject StartButton;
    public GameObject ResetPomsButton;
    [HideInInspector]
    public TimerGUI TimerGUIScript;
    
    [Header("PomodoroNumbers")]
    public int OldPoms;
    public int TotalPoms;
    private int sessionPoms = 0;
    public int SessionPoms
    {
        get
        {
            return sessionPoms;
        }

        set
        {
            sessionPoms = value;
        }
    }

    public void ResetPoms()
    {
        PlayerPrefs.SetInt("Poms", 0);
    }

	// Use this for initialization
	void Start () {
        Application.runInBackground = true;
        timerStartValue = (int)workTime;
        OldPoms = PlayerPrefs.GetInt("Poms");
        TotalPoms = SessionPoms + OldPoms;
        TimerGUIScript = this.gameObject.GetComponent<TimerGUI>();
    }
	
	// Update is called once per frame
	void Update () {
        //timer running
        if (PomodoroTimerEnabled)
        {
            timeLeft = timeLeft - Time.deltaTime;
            StartButton.SetActive(false);
        }
        //timer done
        if(timeLeft <= 0 && PomodoroTimerEnabled)
        {
            PomodoroTimerEnabled = false;
            CalculateNewPomCount();
            timeLeft = relaxTime;
            PlayAudio(EndWorkTimer);
            timerStartValue = (int)timeLeft;

            StartTimer(true);
        }
        //relax timer running
        if (RelaxTimerEnabled)
        {
            timeLeft = timeLeft - Time.deltaTime;
        }
        //relax timer done
        if (timeLeft <= 0 && RelaxTimerEnabled)
        {
            RelaxTimerEnabled = false;
            StartButton.SetActive(true);
            PlayAudio(EndRelaxTimer);
        }


	}

    void CalculateNewPomCount()
    {
        SessionPoms = SessionPoms + 1;
        TotalPoms = OldPoms + SessionPoms;
        PlayerPrefs.SetInt("Poms", SessionPoms + OldPoms);
    }

    void PlayAudio(AudioClip clip)
    {
        Asource.clip = clip;
        Asource.Play();
    }

    public void StartTimer(bool relaxTimer)
    {
        timeLeft = relaxTimer ? relaxTime : workTime;

        PomodoroTimerEnabled = !relaxTimer;
        RelaxTimerEnabled = relaxTimer;

        TimerGUIScript.ChangeImage();
    }
    public void ResetTimer()
    {
        PomodoroTimerEnabled = false;
        timeLeft = timerStartValue;
    }
}
