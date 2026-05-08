using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
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

    private int Conv_Count  = 0;//会話量
     public bool Talkend;//会話終了判定
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AllGameLoop());
    }

    IEnumerator AllGameLoop()
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
                t_controller.TalkUI.SetActive(true);
            }          
            Conv_Count++;
        }
        yield break;
    }
}
