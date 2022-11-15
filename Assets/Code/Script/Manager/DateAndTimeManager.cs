using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateAndTimeManager : MonoBehaviour
{
    public DateTime dateTime;
    
    public String finalDate;
    public String finalMonth;
    public String finalTime;
    public String finalTimePeriod;
    public int finalHour;
    
    public TMP_Text dateText;
    public TMP_Text timeText;
    
    public static DateAndTimeManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    void Start()
    {
        Invoke("Initialize", 1f);
    }
    
    void Initialize()
    {
        dateTime = new DateTime( 
            SaveAndLoadManager.Instance.game.dateAndTime.year, 
            SaveAndLoadManager.Instance.game.dateAndTime.month,
            SaveAndLoadManager.Instance.game.dateAndTime.day, 
            SaveAndLoadManager.Instance.game.dateAndTime.hour,
            SaveAndLoadManager.Instance.game.dateAndTime.minutes,
            SaveAndLoadManager.Instance.game.dateAndTime.seconds
        );
        
        InvokeRepeating("UpdateTime", 0.0f, 0.02f);
    }
    
    public void UpdateTime()
    {
        finalMonth = dateTime.ToString("MMMM");
        finalTime = dateTime.ToString("h:mm");
        finalTimePeriod = dateTime.ToString("tt");

        SaveAndLoadManager.Instance.game.dateAndTime.day = dateTime.Day;
        SaveAndLoadManager.Instance.game.dateAndTime.month = dateTime.Month;
        SaveAndLoadManager.Instance.game.dateAndTime.year = dateTime.Year;
        SaveAndLoadManager.Instance.game.dateAndTime.hour = dateTime.Hour;
        SaveAndLoadManager.Instance.game.dateAndTime.minutes = dateTime.Minute;
        SaveAndLoadManager.Instance.game.dateAndTime.seconds = dateTime.Second;

        finalDate = dateTime.ToString("m");
        
        dateTime = dateTime.AddSeconds ( 10 );
        
        UpdateDateUI(); 
        UpdateTimePeriodUI();
    }
    
    public void UpdateDateUI()
    {
        dateText.text = finalDate;
    }
	
    public void UpdateTimePeriodUI()
    {
        timeText.text = finalTime + " " + finalTimePeriod;
    }
}