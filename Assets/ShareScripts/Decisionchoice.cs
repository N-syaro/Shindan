using UnityEngine;
using UnityEngine.UI;

public class Decisionchoice : MonoBehaviour
{
    [SerializeField]Slider Timeslider;

    [SerializeField] float Maxtime = 5.0f;
    private float currentTime;


    void Start()
    {
        currentTime = Maxtime;

        if (Timeslider != null)
        {
            Timeslider.maxValue = Maxtime;
            Timeslider.value = Maxtime;
        }
    }
    void Update()
    {
       currentTime -= Time.deltaTime;
       
        if  (Timeslider != null)
        {
            Timeslider.value = currentTime;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

    }

}
