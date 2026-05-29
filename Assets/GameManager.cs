
using System;
using System.Collections;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
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
    [Header("オブジェクト参照")]
    [SerializeField]
    GameObject Player_obj;
    [SerializeField]
    GameObject Triangle_obj;

    //private int Conv_Count  = 0;//会話量
    public int Conv_Count = 0;
    public bool endCount;
     public bool Talkend= false;//会話終了判定
    private string sceneName;
    public string NextScene;
    private GameObject ContinuePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(AllGameLoop());
        if(sceneName == "Bad END")
        {
            ContinuePanel = GameObject.Find("Conti_Panel");
            if(ContinuePanel != null)
            {
                ContinuePanel.SetActive(false);
            }
            
        }
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
            switch (sceneName)
            {
                case "JP":
                    {
                        NextScene = "JP Main";
                        Debug.Log("導入シーン用処理");
                        if (Conv_Count == 1)
                        {
                            Debug.Log("シューティングゲーム開始");

                            t_controller.TalkUI.SetActive(false);

                            yield return StartCoroutine(Testshooting.S_Start());
                            
                            yield return new WaitUntil(() => endCount);// シューティング終了待ち
                            endCount = false;
                            
                            t_controller.TalkUI.SetActive(true);// UI再表示
                        }
                        if (Conv_Count == 2)
                        {
                            SceneManager.LoadScene(NextScene);
                        }
                        break;
                    }
                case "JP Main":
                    {
                        NextScene = "END Credits";
                        Debug.Log("本編シーン用処理");
                        Debug.Log("シューティングゲーム開始");

                        t_controller.TalkUI.SetActive(false);

                        yield return new WaitForSeconds(5f);
                        /*
                        yield return StartCoroutine(Testshooting.S_Start());

                        // シューティング終了待ち
                        yield return new WaitUntil(() => endCount > 0);
                        */
                        if (Conv_Count == 3)
                        {
                            Debug.Log("シーン遷移");
                            SceneManager.LoadScene(NextScene);
                        }
                       
                        t_controller.TalkUI.SetActive(true); // UI再表示

                        break;
                    }
                case "END Credits"://エンドクレジット用処理
                    {   
                        NextScene = "EndingScene";
                        if (Conv_Count == 1)
                        {
                            SceneManager.LoadScene(NextScene);
                           
                        }    
                        break;            
                    }
                case "Bad END"://バッドエンド用処理
                    {
                        Debug.Log("バッドエンド用処理");
                        if(Conv_Count == 1)
                        { 
                            if(ContinuePanel != null)
                            {
                                ContinuePanel.SetActive(true);
                            }
                            else
                            {
                                Debug.Log("Conti_Panelがnullです。");
                            }
                            
                        }
                        break;
                    }
            }                       
            // 次へ
            Conv_Count++;
        }
    }
    public void EndShooting(bool i)
    {
        Debug.Log("EndShooting");
        if (i == true)
        {
            endCount = true;
        }
        Player_obj.SetActive(false);
        Triangle_obj.SetActive(false);
    }
    
}
