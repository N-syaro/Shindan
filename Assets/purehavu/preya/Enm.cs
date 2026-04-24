using UnityEngine;

public class Enm : MonoBehaviour
{
    //プレイヤーの効果処理のスクリプト

    bool timeon = false;//タイマースタート
    public float timelemt = 50f;//時間制限
    float taima = 0f;//タイマー
    float taima2 = 0f;//タイマーダメージ
   
    public float demegte = 1f;//ダメージで減らす時間
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {//初期化
        timeon = true;  
        taima = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeon == true)//タイマー処理
        {
            taima = taima2+ Time.time;
            if (taima > timelemt)
            {

                Debug.Log("タイムオーバー");
            }
    

          
        }
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemyに当たったら時間-1
        if (collision.gameObject.tag == "Enemy") 
        {
            Debug.Log("dameg");
            taima2 =+ demegte;

        }
    }
}
