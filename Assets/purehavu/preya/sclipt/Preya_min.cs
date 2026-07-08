using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Preya_min : MonoBehaviour
{
    [SerializeField]
    Enm enm;
    //プレイヤー操作のスクリプト

    Vector2 mousePos;
    Vector2 mouseworldPos;//マウスポインタ位置
    Rigidbody2D Rigidbody2D;
    public bool point = true;//マウスでのキャラ操作の切り替え
    public float sped=10f;//移動速度
    public float dstm=5f; //弾丸消滅速度
    public float brsp = 30f;//弾丸の速度
    public float dlitm=1.5f; //coolタイム
    public float xlimit=8f;
    public float ylimit=7.5f;
    bool hit = false;//ダメージ判定
    public GameObject[] bart;//弾丸のプレハブ
    private float bartcount = 0;//球数カウント
    private string ActiveScene;
    private int phazecount = 0;

    private int balet ;//弾丸の種類
    private float wh;//マウスホイールの数値
    private bool faia=true;
    float taime = 0;//タイマー用の関数

    [Header("点滅用")]
    float flashIntarval = 0.02f;
    int loopCount = 60;
    SpriteRenderer sp;
    bool isHit;

    private void Start()
    {
        ActiveScene = SceneManager.GetActiveScene().name;
        sp = GetComponent<SpriteRenderer>();
        Debug.Log("SpriteRenderer: " + sp);
        Debug.Log("このオブジェクト名: " + gameObject.name);
        this.Rigidbody2D = GetComponent<Rigidbody2D>();
        bartcount=bart.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //マウスポインタの変換
        mousePos = Input.mousePosition;
        mouseworldPos = Camera.main.ScreenToWorldPoint(mousePos);
        
        wh = Input.mouseScrollDelta.y;//マウスホイール取得
       if (wh !=0)//弾丸選択
       {    //マウスホイールの移動
            if (wh > 0) 
            {
                balet++;
            }
            if (wh < 0) 
            {
                balet--;
            }
            //範囲の指定
            if(balet >= bartcount)//bart.Lenght) 
            {
                balet = 0;
            }else if (balet < 0)
            {
                balet = bart.Length-1;
            }       
       }
        
        if (point)//キャラ操作用
        {//マウスの位置へ向けて移動する
            transform.position = Vector2.MoveTowards(transform.position, mouseworldPos, sped * Time.deltaTime);
          
            Vector2 pozi = transform.position;
            pozi.x =Mathf.Clamp(pozi.x,-xlimit,xlimit);
            pozi.y =Mathf.Clamp(pozi.y,-ylimit,ylimit);
            transform.position = pozi;
            taime += Time.deltaTime;
          
            if(Input.GetMouseButtonDown(0))
            { //弾丸発射入力 
                if(faia)
                {
                    if (ActiveScene == "JP")
                    {
                        if (phazecount == 0)
                        { return; }
                    }
                    Debug.Log("弾を打ちました");
                    Shot();
                    faia = false;
                    taime = 0;
                    
                }
                else
                {//クールタイム
                    Debug.Log("cool中");
                   
                    if (taime >= dlitm)
                    {
                        faia = true;
                        taime = 0;
                        Debug.Log("弾が打てます");
                    }
                }
            }
        }    
    }
    void Shot() 
    {//弾丸の発射処理
        GameObject newbalet = Instantiate(bart[balet],this.transform.position,Quaternion.identity);
        Rigidbody2D bllet2d= newbalet.GetComponent<Rigidbody2D>();
        bllet2d.AddForce(this.transform.up* brsp);
        //Destroy(newbalet, dstm);
    }   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
        {
            return;
        }

        if (collision.gameObject.tag == "Enemy" && hit == false)//hit==falseならダメージなし
        {
            hit = true;
            Debug.Log("Hit");

            StartCoroutine(EnemyHit());
        }
    }
    IEnumerator EnemyHit()
    {
        Debug.Log("EnemyHit");
        isHit = true;
        for (int i = 0; i < loopCount; i++)
        {
            yield return new WaitForSeconds(flashIntarval);
            sp.enabled = false;

            yield return new WaitForSeconds(flashIntarval);
            sp.enabled = true;
        }
        isHit = false;
    }
    public void SetBattlephase(int BattlePhase)
    {
        switch (ActiveScene)
        {
            case "JP":
                //フェーズごとに選択できる弾丸の数の調整と制限時間の設定
                switch (BattlePhase)
                {
                    case 0://バトルフェーズ数
                          // enm.ResetToTime(0);//タイマーのリセット
                        break;

                    case 1:
                        phazecount = 1;
                        //enm.ResetToTime(1);
                        break;
                }
                break;
            case "JP Main":
                switch (BattlePhase)
                {
                    case 0://バトルフェーズ数
                        enm.ResetToTime(0);//タイマーのリセット

                        break;
                }
                break;

        }

    }
    private void OnDisable()
    {
        bartcount = 0;
    }
}
