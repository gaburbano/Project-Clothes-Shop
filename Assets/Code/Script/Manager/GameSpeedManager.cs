using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedManager : MonoBehaviour
{
    public Image pauseBtn;
    public Image normalSpeedBtn;
    public Image twoTimeSpeedBtn;

    public enum GAME_SPEED
    {
        PAUSE,
        NORMAL,
        TWO_TIMES
    }
    public GAME_SPEED gameSpeed;
    
    public static GameSpeedManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

        NormalGameSpeed();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NormalGameSpeed();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TwoTimesGameSpeed();
        }
    }
    
    public void Pause()
    {
        GUIUtility.hotControl = 1;
        Time.timeScale = 0;
        
        ResetAll();
        pauseBtn.color = Color.yellow;
        gameSpeed = GAME_SPEED.PAUSE;
    }

    public void NormalGameSpeed()
    {
        GUIUtility.hotControl = 1;
        Time.timeScale = 1;
        
        ResetAll();
        normalSpeedBtn.color = Color.yellow;
        gameSpeed = GAME_SPEED.NORMAL;
    }

    public void TwoTimesGameSpeed()
    {
        GUIUtility.hotControl = 1;
        Time.timeScale = 2f;
        
        ResetAll();
        twoTimeSpeedBtn.color = Color.yellow;
        gameSpeed = GAME_SPEED.TWO_TIMES;
    }

    public void ResetAll()
    {
        pauseBtn.color = Color.white;
        normalSpeedBtn.color = Color.white;
        twoTimeSpeedBtn.color = Color.white;
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
