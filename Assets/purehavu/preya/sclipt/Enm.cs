using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enm : MonoBehaviour
{
    //プレイヤーの効果処理のスクリプト

    [SerializeField] bool timeon = false;//タイマースタート
     [SerializeField] float timelemt = 60f;//時間制限
    [SerializeField] float damegerup=3f;//ダメージを受けた後の無敵時間
    [SerializeField] float cycle=1;
    [SerializeField] float demegte = 5f;//ダメージで減らす時間
    [SerializeField] GameObject temtext=null;

    [SerializeField] float taima = 60f;//タイマー
    bool hit=false;//ダメージ判定
    float damgct;//ダメージ時からの経過時間
    string scenename;//スコアテキスト
    private BoxCollider2D cpplid;
    [Header("点滅用")]
    float flashIntarval = 0.02f;
    int loopCount = 60;
    SpriteRenderer sp;
    bool isHit;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {//初期化
        sp = GetComponent<SpriteRenderer>();
         scenename = SceneManager.GetActiveScene().name;
        
        damgct = 0f;
        cpplid =  GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeon == true)//タイマー処理
        {
            taima -= Time.deltaTime;
           Text taimeli = temtext.GetComponent<Text>();
            taimeli.text = taima.ToString("F0");

            if (taima <= 0f)
            {



                Debug.Log("タイムオーバー");
                if (scenename == "JP Main")
                {
                    SceneManager.LoadScene("Bad END");
                }
            }

            if (hit == true) //ダメージを受けた時の処理
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
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(isHit)
        {
            return;
        }
        
       if (collision.gameObject.tag == "Enemy"&&hit ==false)//hit==falseならダメージなし
       {
            taima -= demegte;
            hit = true;
            Debug.Log("Hit");

            StartCoroutine(EnemyHit());
        }
    }
    //点滅用コルーチン
    IEnumerator EnemyHit()
    {
        isHit = true;
        for(int i = 0; i < loopCount;i++)
        {
            yield return new WaitForSeconds(flashIntarval);
            sp.enabled = false;

            yield return new WaitForSeconds(flashIntarval);
            sp.enabled = true;  
        }
        isHit = false;
    }
    public void ResetToTime(int BattlePhase)
    {
       switch(scenename)
        {
            case "JP":

           　   break;
            case "JP Main":
                switch (BattlePhase)
                {
                    case 0:

                    break;
                }
                break;
        }
    }
}
