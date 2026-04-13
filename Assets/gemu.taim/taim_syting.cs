using UnityEngine;

public class taim_syting : MonoBehaviour
{
    public bool timeon=false;
    public float timeov= 50f;
     float taima=0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeon == true)
        {
            taima = Time.time;
            if (taima > timeov) 
            {

                Debug.Log("タイムオーバー");
            }

        }
        
    }
}
