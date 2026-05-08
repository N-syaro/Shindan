using UnityEngine;

public class gemu_obuge : MonoBehaviour
{
    //敵の生成処理のスクリプト

    public GameObject[] enemiobuject;//生成するゲームオブジェクト
    public float[] spulnt;//生成するタイミング
    float taimudl;//経過時間
    int next = 0;//生成する数
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        taimudl = Time.time;//タイマー
        if (next < spulnt.Length)//順次生成処理
        {

            if (taimudl > spulnt[next])
            {
                sponw();
                next++;
            }
        }

        void sponw()//生成処理
        {

            Instantiate(enemiobuject[next], transform);
            Debug.Log("spon");
        }





    }
}

