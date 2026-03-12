using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Testclick : MonoBehaviour   //これを文字にぶつかってしまったときに呼び出されるスクリプトにする
{
    Timermain timer;
    void Start()
    {
        timer = Object.FindObjectOfType<Timermain>();
    }

    public void OnClick()
    {
        timer.scripttouch();
    }

}
