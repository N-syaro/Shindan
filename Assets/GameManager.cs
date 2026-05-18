using System.Collections;
using Unity.Collections;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    //ゲームマネージャー||メインシーンの全制御
    //会話部分だけ製作します
    //残りのつなぎをお願いします。
    [Header("スクリプト参照")]
    [SerializeField]
    TalkController t_controller;//トークコントローラー（会話制御スクリプト）
    [SerializeField]
    Testshooting Testshooting;
    [Header("データ参照")]
    [SerializeField]
    MakeConversation[] makeConversations;//会話データ配列(体験版使用)本番はリスト化したい

    //private int Conv_Count  = 0;//会話量
    public int Conv_Count = 0;
    public int endCount = 0;
     public bool Talkend;//会話終了判定
    private string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(AllGameLoop());
    }

    /*IEnumerator AllGameLoop()
    {
        while (Conv_Count<makeConversations.Length)
        {
            t_controller.SetObject(makeConversations[Conv_Count]);
            yield return new WaitUntil(()=>Talkend);
            Talkend = false;
            if(Conv_Count == 1)
            {
                Debug.Log("シューティングゲーム開始");
                t_controller.TalkUI.SetActive(false);
                yield return StartCoroutine(Testshooting.S_Start());
                if (endCount == 1)
                {   
                    t_controller.TalkUI.SetActive(true);
                }
               
            }          
            Conv_Count++;
        }
        yield break;
    }*/
    IEnumerator AllGameLoop()
    {
        while (Conv_Count < makeConversations.Length)
        {
            // 会話開始
            t_controller.SetObject(makeConversations[Conv_Count]);

            // 会話終了待ち
            yield return new WaitUntil(() => Talkend);

            Talkend = false;
          /* 製作途中です　中塚
           if(sceneName == "")
            {//導入シーン
                Debug.Log("導入シーン用処理");
                if (Conv_Count == 1)
                {
                    Debug.Log("シューティングゲーム開始");

                    t_controller.TalkUI.SetActive(false);

                    yield return StartCoroutine(Testshooting.S_Start());

                    // シューティング終了待ち
                    yield return new WaitUntil(() => endCount > 0);

                    // UI再表示
                    t_controller.TalkUI.SetActive(true);


                }
            }
            if(sceneName == "")
            {//本編シーン
                Debug.Log("本編シーン用処理");
                if (Conv_Count == 1)
                {
                    Debug.Log("シューティングゲーム開始");

                    t_controller.TalkUI.SetActive(false);

                    yield return StartCoroutine(Testshooting.S_Start());

                    // シューティング終了待ち
                    yield return new WaitUntil(() => endCount > 0);

                    // UI再表示
                    t_controller.TalkUI.SetActive(true);


                }
            }*/
            // 2回に1回実行
            if ((Conv_Count + 1) % 2 == 0)
            {
                Debug.Log("シューティングゲーム開始");

                t_controller.TalkUI.SetActive(false);

                yield return StartCoroutine(Testshooting.S_Start());

                // シューティング終了待ち
                yield return new WaitUntil(() => endCount > 0);

                // UI再表示
                t_controller.TalkUI.SetActive(true);

                
            }

            // 次へ
            Conv_Count++;
        }
    }
}
