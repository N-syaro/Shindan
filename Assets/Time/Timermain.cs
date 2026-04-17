using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class Timermain : MonoBehaviour
{
    public int countdownMinutes = 5;

    private float countdownSeconds;

    private Text timerText;

    private bool isPaused = false;

    private void Start()
    {
        timerText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;
    }

  public void Countdown()　//シューティングシーンの間ずっと呼び出される
    {
        if (!isPaused && countdownSeconds > 0)
        {
            countdownSeconds -= Time.deltaTime;//?秒1秒ずつ
            UpdateTimer();
        }
        
    }

  public void Countstop()
    {
        isPaused = true;//一時停止
    }

  public void Countgiveup()
    {
        isPaused = false;//再開
    }
   public void scripttouch()　　//文字にぶつかってしまったときに呼び出される
    {

        countdownSeconds -= 30.0f;//のちに変更する可能性あり
        UpdateTimer();
        

    }
    private void UpdateTimer()
    {
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timerText.text = span.ToString(@"mm\:ss");
    }


}
