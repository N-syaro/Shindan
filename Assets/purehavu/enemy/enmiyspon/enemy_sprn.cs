using UnityEngine;

public class enemy_sprn : MonoBehaviour
{
    //敵のアクション処理スクリプト

    public Vector2[] weipos;//移動の目標地点
    public float mube=5f;//移動時間
    public bool culafl=false;//クリアフラグ
    int pint=0;//移動ポイントの数
    [SerializeField] bool next=false;//クリア用オブジェクトはtrue
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)//当たり判定
    {
        if (next!)
        {
            if (collision.gameObject.tag == "ballt")//balltタグに当たったらクリアフラグを立てる
            {
                culafl = true;
                Debug.Log(culafl);

            }

        }


    }
    void Update()
    {

        if (weipos==null||weipos.Length==0) return;//未設定の際の処理

         //ウェイポイントへ向けて移動する
         Vector2 taget = weipos[pint];
         transform.position=Vector2.MoveTowards(transform.position, taget, mube * Time.deltaTime);

        if(Vector2.Distance(transform.position, taget)<0.001f)//移動した後のポイント更新
        {
            pint++;
            if (pint >= weipos.Length) //移動完了後削除
            {
                Destroy(this.gameObject);
            }
        }
        
        
    }
   


}
