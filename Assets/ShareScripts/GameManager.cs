
using System;
using System.Collections;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    [SerializeField]
    Sprite[] Exp_Sprites;//説明用イメージ配列
    [Header("オブジェクト参照")]
    [SerializeField]
    GameObject Player_obj;
    [SerializeField]
    public GameObject[] Enemy_obj;
    [SerializeField]
    GameObject Exp_Panel;//説明用パネル
    [SerializeField]
    Image Exp_Image;//説明用イメージ

    //private int Conv_Count  = 0;//会話量
    public int mainloopcount = 0;  
    public int Enemycount = 0;
    public int Conv_Count = 0;
    public int Talk_Count = 0;
    public int Battle_Count = 1;
    public bool endCount = false;
    public bool Talkend= false;//会話終了判定
    public bool Exp_end = false;//説明1終了判定
    public bool Exp2_end = false;//説明2終了判定
    private bool isloop = true;
    private bool isbattleloop = false;
    private bool isIncorrect = false;
    private string sceneName;
    public string NextScene;
      
    private GameObject ContinuePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(AllGameLoop());
        switch (sceneName)
        { case "JP":
            {
                Exp_Panel.SetActive(false);
                break;
            }
            case "Bad END":
            {
                ContinuePanel = GameObject.Find("Conti_Panel");
                if(ContinuePanel != null)
                {
                         ContinuePanel.SetActive(false);
                }
                break;  
            }
        }
    }
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
                case "JP"://導入シーン用処理-------------------------------------------------------------------------------------------------------------------
                    {
                        NextScene = "JP Main";
                        Debug.Log("導入シーン用処理");
                        if (Conv_Count == 1)
                        {
                            Debug.Log("操作説明１のUI表示");
                            Exp_Panel.SetActive(true);
                            Exp_Image.sprite = Exp_Sprites[0];
                            yield return new WaitUntil(() => Exp_end);
                            Exp_Panel.SetActive(false);
                            Exp_end = false;    

                            Debug.Log("シューティングゲーム開始");
                            t_controller.TalkUI.SetActive(false);
                            Enemycount = 0;
                            yield return StartCoroutine(Testshooting.S_Start(0));                            
                            yield return new WaitUntil(() => endCount);// シューティング終了待ち
                            endCount = false; 

                            Debug.Log("操作説明2のUI表示");
                            Exp_Panel.SetActive(true);
                            Exp_Image.sprite = Exp_Sprites[1];
                            yield return new WaitUntil(() => Exp_end);
                            Exp_Panel.SetActive(false);
                            Exp_end = false;
                             
                            
                            Debug.Log("シューティングゲーム再突入");
                            Enemycount = 1;
                            yield return StartCoroutine(Testshooting.S_Start(1));
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
                case "JP Main"://本編シーン処理----------------------------------------------------------------------------------------------------------------
                    {
                        NextScene = "END Credits";//次のシーン決め
                        Debug.Log("本編シーン用処理");
                        Enemycount = 0;
                        Talk_Count = 1;
                        while (isloop)
                        {
                            Debug.Log("本編ループ開始");
                            Debug.Log("シューティングゲーム開始");
                            Debug.Log(mainloopcount);
                            t_controller.TalkUI.SetActive(false);
                            yield return StartCoroutine(Testshooting.S_Start(mainloopcount));
                            yield return new WaitUntil(() => endCount);// シューティング終了待ち
                            Debug.Log("シューティング終わり");
                            endCount = false;
                            switch (mainloopcount)
                            {
                                case 0: case 1:case 2:case 3: //4バトル分同じ処理
                                    yield return new WaitUntil(() => Talkend);
                                    Talkend = false;
                                    Debug.Log("カウンセリング開始");
                                    if(isbattleloop)
                                    {
                                        Debug.Log(Battle_Count + "回目");
                                        isbattleloop = true;
                                        mainloopcount++;
                                        Enemycount++;
                                        Talk_Count++;
                                        Battle_Count++;

                                        break;
                                    }
                                    else if(isIncorrect)
                                    {

                                    }
                                    else
                                    {                                    
                                    Debug.Log("dd");
                                    EnemyReset();
                                    t_controller.TalkUI.SetActive(true);// UI再表示
                                    t_controller.SetObject(makeConversations[Talk_Count]);
                                    yield return new WaitUntil(() => Talkend);
                                    Talkend = false;

                                    }

                                 break;

                                case 4://最後のバトル
                                    yield return new WaitUntil(() => Talkend);
                                    Talkend = false;
                                    if (isbattleloop)
                                    {
                                        Debug.Log("シーン遷移");
                                        SceneManager.LoadScene(NextScene);
                                        break;
                                    }
                                    else
                                    {
                                        EnemyReset();
                                    t_controller.TalkUI.SetActive(true);// UI再表示
                                    t_controller.SetObject(makeConversations[3]);
                                    yield return new WaitUntil(() => Talkend);
                                    Talkend = false;
                                    }

                                 break;
                            }
                            Debug.Log("switch抜け出し");
                        }
                        Debug.Log("loop抜け出し");
                        break;
                    }
                case "END Credits"://エンドクレジット用処理-----------------------------------------------------------------------------------------------------
                    {   
                        NextScene = "EndingScene";
                        if (Conv_Count == 1)
                        {
                            SceneManager.LoadScene(NextScene);
                           
                        }    
                        break;            
                    }
                case "Bad END"://バッドエンド用処理--------------------------------------------------------------------------------------------------------------
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
            Debug.Log(endCount);
        }
        if(sceneName == "JP")
        {   
            Player_obj.SetActive(false);
            Enemy_obj[Enemycount].SetActive(false);
        }
    
    }
    public void EndExp()
    {
        Debug.Log("EndExp");
            Exp_end = true;      
    }
    public void EnemyReset()//敵のリセット
    {
        Debug.Log("EnemyReset読み込み");
        Debug.Log(Enemycount);
        Enemy_obj[Enemycount].SetActive(false);
        //主人公のタイマーを止めるプログラム挿入箇所
    }
    public void IsBattle()
    {
        isbattleloop = true;
    }
    public void HitBalletNumber(int i)//本編以外でも使いまわしできます。
    {
        EnemyReset();
        t_controller.TalkUI.SetActive(true);// TalkUI再表示
        switch(Battle_Count)
        { 
                case 1: //バトル1----------------------------------
                switch (i)
                {
                    case 1://肯定
                        Debug.Log("正解");
                        isbattleloop = true;
                        t_controller.SetObject(makeConversations[4]);
                        
                        break;

                    case 2://否定
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[5]);
                        break;
                }
                break;　

                case 2: //バトル2----------------------------------
                switch (i)
                {
                    case 1://肯定
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[6]);
                        break;

                    case 2://否定
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[7]);
                        break;

                    case 3://反論
                        Debug.Log("正解");
                        isbattleloop = true;
                        t_controller.SetObject(makeConversations[8]);
                        
                        break;

                }
                break;

                case 3: //バトル3----------------------------------
                switch (i)
                {
                    case 1://肯定
                        Debug.Log("正解");
                        isbattleloop = true;
                        t_controller.SetObject(makeConversations[9]);
                        
                        break;
                    case 2://否定
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[10]);
                        break;
                }
                break;

                case 4: //バトル4----------------------------------
                switch (i)
                {
                    case 1://肯定
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[11]);
                        break;

                    case 2://否定
                        Debug.Log("正解");
                        isbattleloop = true;
                        t_controller.SetObject(makeConversations[12]);
                        
                        break;

                    case 3://謎
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[13]);
                        break;
                }
                break;

                case 5: //バトル5----------------------------------
                switch (i)
                {
                    case 1://共感
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[14]);
                        break;

                    case 2://ポジティブ否定
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[15]);
                        break;

                    case 3://ネガティブ肯定
                        Debug.Log("正解");
                        isbattleloop = true;
                        t_controller.SetObject(makeConversations[16]);
                       
                        break;

                    case 4://ネガティブ否定
                        Debug.Log("不正解");
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[17]);
                        break;
                }
                break;

        }
        Debug.Log("ここまで抜けた");
    }
    
}
