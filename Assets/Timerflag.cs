using Unity.VisualScripting;
using UnityEngine;

public class Timerflag : MonoBehaviour
{
    private void Update()
    {
        Timermain timer = FindObjectOfType<Timermain>();

        if (timer != null)
        {
            timer.Countdown();
        }
    }
}    

