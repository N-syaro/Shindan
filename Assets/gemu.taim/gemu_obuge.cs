using UnityEngine;

public class gemu_obuge : MonoBehaviour
{
    public GameObject[] enemiobuject;//生成するゲームオブジェクト
    public float[] spulnt;
   float taimudl;
    int next = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        taimudl = Time.time;
        if (next < spulnt.Length)
        {
           
            if (taimudl > spulnt[next]) 
            {
                sponw();
                next++;
            }
        }

        void sponw()
        {
            
            Instantiate(enemiobuject[next]);
            Debug.Log("spon");
        }





    }
}
