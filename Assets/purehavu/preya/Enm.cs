using UnityEngine;
using UnityEngine.iOS;

public class Enm : MonoBehaviour
{
    //プレイヤーの効果処理のスクリプト

  [SerializeField] bool timeon = false;//タイマースタート
   [SerializeField] float timelemt = 50f;//時間制限
    [SerializeField] float damegerup=3f;
    private BoxCollider2D cpplid;
    float taima = 0f;//タイマー
    float taima2 = 0f;//タイマーダメージ
    bool hit=false;
    float damgct;


   
    public float demegte = 1f;//ダメージで減らす時間
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {//初期化
         
        taima = 0f;
        damgct = 0f;
        cpplid =  GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeon == true)//タイマー処理
        {
            taima += taima2+ Time.deltaTime;
            
            if (taima > timelemt)
            {

                Debug.Log("タイムオーバー");
            }
    

          
        }
        if (hit == true) 
        {
            damgct += Time.deltaTime;
            if (damegerup < damgct) 
            {
                hit = false;
                damgct = 0f;
                Debug.Log(hit);
            }

        }

     
    }

  
   
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        
       if (collision.gameObject.tag == "Enemy"&&hit ==false)
       {
            hit = true;
            Debug.Log(hit);
            
        }
    }
    
}
