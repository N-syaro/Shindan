using Unity.VisualScripting;
using UnityEngine;

public class gemu_obuge : MonoBehaviour
{
    //敵の生成処理のスクリプト
   
    public bool stat=true;
    public GameObject[] enemiobuject;//生成するゲームオブジェクト
    public float[] spulnt;//生成するタイミング
    float taimudl;//経過時間
    int next = 0;//生成する数
    bool onstop;
    GameObject gamemanager;
    GameManager dawe;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        /*gamemanager = GameObject.Find("GameManagar");
        dawe = gamemanager.GetComponent<GameManager>();
        */

    }

    

    // Update is called once per frame
    void Update()
    {
        if (enemiobuject==null)return;



       


        if (stat == true)
        {
            
            taimudl += Time.deltaTime;
            //タイマー

           

         
         
            if (next < taimudl&& next<spulnt.Length)//順次生成処理
            {

                if (taimudl  >spulnt[next])
                {
                    sponw();
                    next++;
                }
            }
           /* else if (next >= spulnt.Length) 
            {
                dawe.endCount=true;
                Debug.Log(dawe.endCount);
            }
           */
           
        }




    }
    void sponw()//生成処理
    {

        Instantiate(enemiobuject[next]);
        Debug.Log("spon");
    }
}

