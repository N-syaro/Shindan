using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stop : MonoBehaviour
{
    Timermain timer;
    private void Update()
    {
    timer = FindObjectOfType<Timermain>();
    }

    public void Click()
    {
        timer.Countstop();//ˆêŽž’âŽ~
    }

}
