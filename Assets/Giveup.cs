using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Giveup : MonoBehaviour
{
    Timermain timer;
    private void Update()
    {
       timer = FindObjectOfType<Timermain>();
    }

    public void More()
    {
        timer.Countgiveup();//タイマー再開
    }
}
