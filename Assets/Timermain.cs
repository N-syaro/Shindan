using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Timermain : MonoBehaviour
{
    public int countdownMinutes = 5;

    private float countdownSeconds;

    private Text timerText;

    

    private void Start()
    {
        timerText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;
    }

  public void Countdown()　//シューティングシーンの間ずっと呼び出される
    {
            countdownSeconds -= Time.deltaTime;//?秒1秒ずつ
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timerText.text = span.ToString(@"mm\:ss");
    }

   public void scripttouch()　　//文字にぶつかってしまったときに呼び出される
    {

        countdownSeconds -= 5.0f;//のちに変更する可能性あり
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timerText.text = span.ToString(@"mm\:ss");

    }

}
