using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Preya_min : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 mouseworldPos;//マウスポインタ位置
    public bool point = true;//マウスでのキャラ操作の切り替え
    public float sped=10f;//移動速度
    public float dstm=5f; //弾丸消滅速度
    public float brsp = 1000f;//弾丸の速度
    public float dlitm=5f; //coolタイム
    public GameObject[] bart;//弾丸のプレハブ

    private int balet ;//弾丸の種類
    private float wh;//マウスホイールの数値
    private bool faia=true;
    float taime = 0;//タイマー用の関数
    private void Start()
    {
       
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
            if(balet >= bart.Length) 
            {
                balet = 0;
            }else if (balet < 0)
            {
                balet = bart.Length-1;
            }

            Debug.Log(balet);

       }
  

       
        if (point)//キャラ操作用
        {//マウスの位置へ向けて移動する
            transform.position = Vector2.MoveTowards(transform.position, mouseworldPos, sped * Time.deltaTime);
          
            taime += Time.deltaTime;
            if(Input.GetMouseButtonDown(0))
            {
                if(faia)
                {
                    Debug.Log("弾を打ちました");
                    Shot();
                    faia = false;
                    taime = 0;
                    Debug.Log(taime);
                }
                else
                {
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
        Destroy(newbalet, dstm);

    }

}
