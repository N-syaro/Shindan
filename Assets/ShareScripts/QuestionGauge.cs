using UnityEngine;
using UnityEngine.UI;

public class QuestionGauge : MonoBehaviour
{
    [SerializeField]
    GameManager Gm;
    [SerializeField]
    Slider TimeGauge;//カウントダウンゲージ用スライダー
    [SerializeField]
    float taima = 5f;//タイマー
    private float QuestionTime;//シンキングタイム(ゲージに同期させたい）
    private void OnEnable()//アクティブ時処理
    {
        //タイムカウントダウン開始処理
        taima = 5f;

    }
    private void OnDisable()//非アクティブ時処理
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         ＊このスクリプトの必要事項
        　・カウントダウン処理
        　・それをスライダー（ゲージ）と同期させる
        　・カウントダウン終了時に下記のコード読み込み
          ・上記の二つのOnEna.OnDisの処理
          ・追加あれば制作お願いします。
         */
        taima -= Time.deltaTime;
        TimeGauge.value = taima;


        if (taima <= 0 )
        {
            Gm.Questionend = true; Gm.Talkend = true;
        }

        
    }
}
