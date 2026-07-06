using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_sprn : MonoBehaviour
{
    //敵のアクション処理スクリプト

    public Vector2[] weipos;//移動の目標地点
    public float mube = 5f;//移動時間
    public bool culafl = false;//クリアフラグ
    int pint = 0;//移動ポイントの数
    [SerializeField] bool next = false;//クリア用オブジェクトはtrue
     GameManager Gm;
    Testshooting Ts;
    string ActiveSceneName;
    GameObject G_mana;
    private bool isHitProcessing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    private void Start()
    {
        ActiveSceneName = SceneManager.GetActiveScene().name;
        G_mana = GameObject.Find("GameManager");
        Gm = G_mana.GetComponent<GameManager>();
        Ts = G_mana.GetComponent<Testshooting>();
    }
    private void OnCollisionEnter2D(Collision2D collision)//当たり判定
    {

        if (this.tag != "neo")
        {
            return;
        }
        if (isHitProcessing)
        {
            return;
        }
        //ここにコルーチン         
        switch (ActiveSceneName)
        {
            case "JP":
                if (collision.gameObject.tag == "Ballet1")//balltタグに当たったらクリアフラグを立てる
                {
                    if (G_mana != null)
                    {
                        Gm.EnemyReset();
                        G_mana.GetComponent<GameManager>().EndShooting(true);
                    }
                    culafl = true;
                    Debug.Log(culafl);
                    Debug.Log("当たった！！");
                    G_mana.GetComponent<Testshooting>().HitReaction(true);
                }

                break;
            case "JP Main":
                switch (collision.gameObject.tag)
                {
                    case "Ballet1":
                        Debug.Log("弾1");
                        Ts.HitReaction(true);
                        Gm.EndShooting(true);
                        Gm.LoadImageCol(1);
                        
                        break;
                    case "Ballet2":
                        Debug.Log("弾2");
                        Ts.HitReaction(true);
                        Gm.EndShooting(true);
                        Gm.LoadImageCol(2);
                        break;
                    case "Ballet3":
                        Debug.Log("弾3");
                        Ts.HitReaction(true);
                        Gm.EndShooting(true);
                        Gm.LoadImageCol(3);
                        break;
                    case "Ballet4":
                        Debug.Log("弾4");
                        Ts.HitReaction(true);
                        Gm.EndShooting(true);
                        Gm.LoadImageCol(4);
                        break;
                }
                break;
        }
    }
    public void ResetHit()
    {
        isHitProcessing = false;
    }
    void Update()
    {

        if (weipos == null || weipos.Length == 0) return;//未設定の際の処理

        //ウェイポイントへ向けて移動する
        Vector2 taget = weipos[pint];
        transform.position = Vector2.MoveTowards(transform.position, taget, mube * Time.deltaTime);

        if (Vector2.Distance(transform.position, taget) < 0.001f)//移動した後のポイント更新
        {
            pint++;
            if (pint >= weipos.Length) //移動完了後削除
            {
                Destroy(this.gameObject);
            }
        }


    }
} 
