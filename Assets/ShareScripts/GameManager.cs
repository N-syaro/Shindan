
using System;
using System.Collections;
using System.Net;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [Header("スクリプト参照")]
    [SerializeField]
    TalkController t_controller;//トークコントローラー（会話制御スクリプト）
    [SerializeField]
    Testshooting Testshooting;
    [SerializeField]
    Preya_min player_;
    [SerializeField]
    FadeOutIn fadeOutIn;
    [SerializeField]
    Enm enm;
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
    [SerializeField]
    GameObject Current_Img;
    [SerializeField]
    GameObject ShootingPanel;
    [SerializeField]
    GameObject QuestionPanel;
    private GameObject ContinuePanel;
    [Header("ShootingUI参照")]
    [SerializeField]
    GameObject[] AmmosUI;
    [SerializeField]
    Text[] AmmosName;
   


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
    public bool Questionend = false;
    private bool isloop = true;
    private bool isbattleloop = false;
    private bool isIncorrect = false;
    private bool isQuestion = false;
    private bool ThinkingTimeOut = false;
    private string sceneName;
    public string NextScene;
   
    private float fadeOutDuration = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(AllGameLoop());
        switch (sceneName)//各シーンの設定
        { case "JP":
            case "EN":
            {
                Exp_Panel.SetActive(false);
                    ShootingPanel.SetActive(false);
                    break;
            }
            case "JP Main":
            case "EN Main":
                QuestionPanel.SetActive(false);
                ShootingPanel.SetActive(false);
                break;
            case "Bad END":
            case "EN Bad END":
                {
                ContinuePanel = GameObject.Find("Conti_Panel");
                if(ContinuePanel != null)
                {
                         ContinuePanel.SetActive(false);
                }
                break;
                }
        }
        switch (sceneName)//言語設定
        {
            case "JP":
            case "JP Main":
            case "END Credits":
            case "Bad End":
                GameSettings.CurrentLanguage = Language.Japanese;
                break;
            case "EN":
            case "EN Main":
            case "EN END Credits":
            case "EN Bad End":
                GameSettings.CurrentLanguage = Language.English;
                break;

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
                case "JP":
                case "EN"://導入シーン用処理-------------------------------------------------------------------------------------------------------------------
                    {
                        if(sceneName == "JP")
                        {
                            NextScene = "JP Main";
                        }
                        else if(sceneName == "EN")
                        {
                            NextScene = "EN Main";
                        }
                        
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
                            ShootingPanel.SetActive(true);
                            AmmoUIManagment(0);                            
                            t_controller.TalkUI.SetActive(false);
                            Enemycount = 0;
                            yield return StartCoroutine(Testshooting.S_Start(0));                            
                            yield return new WaitUntil(() => endCount);// シューティング終了待ち
                            endCount = false;
                            ShootingPanel.SetActive(false);

                            Debug.Log("操作説明2のUI表示");
                            Exp_Panel.SetActive(true);
                            Exp_Image.sprite = Exp_Sprites[1];
                            yield return new WaitUntil(() => Exp_end);
                            Exp_Panel.SetActive(false);
                            Exp_end = false;
                             
                            
                            Debug.Log("シューティングゲーム再突入");
                            ShootingPanel.SetActive(true);
                            AmmoUIManagment(1);
                            Enemycount = 1;
                            yield return StartCoroutine(Testshooting.S_Start(1));
                        　　yield return new WaitUntil(() => endCount);// シューティング終了待ち
                            endCount = false;
                            ShootingPanel.SetActive(false);
                            t_controller.TalkUI.SetActive(true);// UI再表示
                        }
                        if (Conv_Count == 2)
                        {
                            yield return null;

                            //fadeOutIn.fadeOut(2f);

                            yield return new WaitForSeconds(2f);

                            SceneManager.LoadScene(NextScene);

                            //シーンが変わったとき　そちらにフェードインをさせる


                           AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NextScene);


                            fadeOutIn.fadeIn(0.0f, 1.0f);
                            //fadeOutIn.fadeIn(0f, 1f);
                        }
                        break;
                    }
                case "JP Main":
                case "EN Main"://本編シーン処理----------------------------------------------------------------------------------------------------------------
                    {
                        yield return null;
                        if (sceneName == "JP Main")
                        {
                            NextScene = "END Credits";
                        }
                        else if (sceneName == "EN Main")
                        {
                            NextScene = "EN END Credits";
                        }
                        Debug.Log("本編シーン用処理");
                        Enemycount = 0;
                        Talk_Count = 1;
                        while (isloop)
                        {
                            Debug.Log("本編ループ開始");
                            Debug.Log("シューティングゲーム開始");
                            Debug.Log(mainloopcount);
                            switch (mainloopcount)
                            {
                                case 0:
                                case 1:
                                case 2: //3バトル分同じ処理
                                    QuestionPanel.SetActive(false);
                                    ShootingPanel.SetActive(true);
                                    t_controller.TalkUI.SetActive(false);
                                    AmmoUIManagment(Battle_Count);
                                    yield return StartCoroutine(Testshooting.S_Start(mainloopcount));
                                    yield return new WaitUntil(() => endCount);// シューティング終了待ち
                                    ShootingPanel.SetActive(false);
                                    Debug.Log("シューティング終わり");
                                    endCount = false;
                                    yield return new WaitUntil(() => Talkend);
                                    Talkend = false;
                                    Debug.Log("カウンセリング開始");
                                    if (isbattleloop)
                                    {
                                        Debug.Log(Battle_Count + "回目");
                                        isbattleloop = false;
                                        mainloopcount++;
                                        Enemycount++;
                                        Talk_Count++;
                                        Battle_Count++;

                                        break;
                                    }
                                    else if (isIncorrect)
                                    {
                                        isIncorrect = false;
                                        break;
                                    }
                                    else
                                    {
                                        EnemyReset();
                                        t_controller.TalkUI.SetActive(true);// UI再表示
                                        t_controller.SetObject(makeConversations[Talk_Count]);
                                        yield return new WaitUntil(() => Talkend);
                                        Talkend = false;
                                    }

                                    break;
                                case 3://選択肢表示フェーズ
                                    ShootingPanel.SetActive(false);
                                    if (t_controller.TalkUI.activeSelf == false)
                                    {
                                        t_controller.TalkUI.SetActive(true);// UI再表示
                                    }
                                    t_controller.SetObject(makeConversations[18]);//選択肢用特別配列
                                    yield return new WaitUntil(() => Talkend);
                                    Talkend = false;
                                    t_controller.TalkUI.SetActive(true);
                                    QuestionPanel.SetActive(true);
                                    yield return new WaitUntil(() => Questionend);
                                    Questionend = false;
                                    yield return new WaitUntil(() => Talkend);
                                    Talkend = false;
                                    if (isQuestion)
                                    {
                                        Battle_Count++;
                                        mainloopcount++;
                                    }
                                    else  if(ThinkingTimeOut)
                                    {
                                        yield return new WaitUntil(() => Questionend);
                                        Questionend = false;
                                        QuestionPanel.SetActive(false);
                                        t_controller.SetObject(makeConversations[13]);
                                        yield return new WaitUntil(() => Talkend);
                                        Talkend = false;
                                    }
                                    break;
                                case 4://最後のバトル
                                    QuestionPanel.SetActive(false);
                                    ShootingPanel.SetActive(true);
                                    t_controller.TalkUI.SetActive(false);
                                    AmmoUIManagment(Battle_Count);
                                    yield return StartCoroutine(Testshooting.S_Start(mainloopcount));
                                    yield return new WaitUntil(() => endCount);// シューティング終了待ち
                                    ShootingPanel.SetActive(false);
                                    Debug.Log("シューティング終わり");
                                    endCount = false;
                                    yield return new WaitUntil(() => Talkend);
                                    Talkend = false;
                                    if (isbattleloop)
                                    {
                                        Debug.Log("シーン遷移");
                                        SceneManager.LoadScene(NextScene);
                                        break;
                                    }
                                    else if (isIncorrect)
                                    {
                                        isIncorrect = false;
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
                case "END Credits":
                case "EN END Credits"://エンドクレジット用処理-----------------------------------------------------------------------------------------------------
                    {   
                        NextScene = "EndingScene";
                        if (Conv_Count == 1)
                        {
                            
                            SceneManager.LoadScene(NextScene);
                           
                        }    
                        break;            
                    }
                case "Bad END":
                case "EN Bad END"://バッドエンド用処理--------------------------------------------------------------------------------------------------------------
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
        foreach(GameObject E_bullet in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(E_bullet);
        }
        Enemy_obj[Enemycount].SetActive(false);
        Player_obj.SetActive(false);
        //主人公のタイマーを止めるプログラム挿入箇所
    }
    public void IsBattle()
    {
        isbattleloop = true;
    }
    public void LoadImageCol(int i)
    {
        StartCoroutine(HitBalletNumber(i));
    }
    public void IsQuestion(bool i)
    {
        QuestionPanel.SetActive(false);
        if(i)
        {
            LoadImageCol(1);
            isQuestion = false;
        }
        else
        {
            LoadImageCol(2);
            isQuestion = true;
        }
    }
    IEnumerator CurrentImage()
    {
        Debug.Log("CurrentImg読み込み");
        Current_Img.SetActive(true);
        yield return new WaitForSeconds(2f);
        Current_Img.SetActive(false);
        t_controller.TalkUI.SetActive(true);
        Debug.Log("CurrentImage読み込み終わり");
        yield break;
    }
    private void AmmoUIManagment(int BattleCount)
    {
        Debug.Log("Ammos_mana読み込み");
        switch (sceneName)
        {
            case "JP":
                switch (BattleCount)
                {
                    case 0:
                        AmmosUI[0].SetActive(false);
                        AmmosUI[1].SetActive(false);
                        AmmosUI[2].SetActive(false);
                        AmmosUI[3].SetActive(false);
                    break;
                    case 1:
                        AmmosUI[0].SetActive(true);
                        AmmosName[0].text = "質問";
                    break;
                }               
            break;
            case "JP Main":
                switch(BattleCount)
                {
                    case 1://バトル１
                        AmmosUI[2].SetActive(false);
                        AmmosUI[3].SetActive(false);
                        AmmosName[0].text = "肯定";
                        AmmosName[1].text = "否定";
                        break;
                    case 2://バトル２
                        AmmosUI[2].SetActive(true);
                        AmmosName[2].text = "反論";
                        break;
                    case 3://バトル３
                        AmmosUI[2].SetActive(true);
                        AmmosName[2].text = "......";
                        break;
                    case 4://バトル４
                        break;
                    case 5://バトル５
                        AmmosUI[3].SetActive(true);
                        AmmosName[0].text = "共感";
                        AmmosName[1].text = "ポジティブ否定";
                        AmmosName[2].text = "ネガティブ肯定";
                        AmmosName[3].text = "ネガティブ否定";
                        break;
                }
            break;
        }
        Debug.Log("Ammos_mana抜け出し");
    }
    public IEnumerator HitBalletNumber(int i)//本編以外でも使いまわしできます。
    {
        EnemyReset();
       
        switch(Battle_Count)
        { 
                case 1: //バトル1----------------------------------
                switch (i)
                {
                    case 1://肯定
                        Debug.Log("正解");
                        yield return StartCoroutine(CurrentImage());                       
                        isbattleloop = true;
                        Debug.Log("Setobject前");
                        t_controller.SetObject(makeConversations[4]);
                        Debug.Log("バトル1終了");
                        enm.onactiv=true;
                        break;

                    case 2://否定
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[5]);
                    break;
                    default:
                        Debug.Log("回答以外の弾");
                        Talkend = true;
                        break;
                }
                break;　

                case 2: //バトル2----------------------------------
                switch (i)
                {
                    case 1://肯定
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[6]);
                        break;

                    case 2://否定
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[7]);
                        break;

                    case 3://反論
                        Debug.Log("正解");
                        yield return StartCoroutine(CurrentImage());
                        isbattleloop = true;
                        t_controller.SetObject(makeConversations[8]);
                        enm.onactiv = true;
                        break;
                    default:
                        Debug.Log("回答以外の弾");
                        Talkend = true;
                        break;
                }
                break;

                case 3: //バトル3----------------------------------
                switch (i)
                {
                    case 1://肯定
                        Debug.Log("正解");
                        yield return StartCoroutine(CurrentImage());
                        isbattleloop = true;
                        t_controller.SetObject(makeConversations[9]);
                        enm.onactiv = true;
                        break;
                    case 2://否定
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[10]);
                        break;
                    case 3://聞いてない
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[13]);
                        break;
                    default:
                        Debug.Log("回答以外の弾");
                        Talkend = true;
                        break;
                }
                break;

                case 4: //バトル4----------------------------------
                switch (i)
                {
                    case 1://肯定
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        Questionend = true;
                        t_controller.SetObject(makeConversations[11]);
                        break;

                    case 2://否定
                        Debug.Log("正解");
                        yield return StartCoroutine(CurrentImage());
                        isbattleloop = true;
                        Questionend = true;
                        t_controller.SetObject(makeConversations[12]);
                        enm.onactiv = true;
                        break;

                    case 3://聞いてない
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[13]);
                        break;
                    default:
                        Debug.Log("回答以外の弾");
                        Talkend = true;
                        break;
                }
                break;

                case 5: //バトル5----------------------------------
                switch (i)
                {
                    case 1://共感
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[14]);
                        break;

                    case 2://ポジティブ否定
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[15]);
                        break;

                    case 3://ネガティブ肯定
                        Debug.Log("正解");
                        yield return StartCoroutine(CurrentImage());
                        isbattleloop = true;
                        t_controller.SetObject(makeConversations[16]);
                        enm.onactiv = true;
                        break;

                    case 4://ネガティブ否定
                        Debug.Log("不正解");
                        t_controller.TalkUI.SetActive(true);
                        isIncorrect = true;
                        t_controller.SetObject(makeConversations[17]);
                        break;
                }
                break;
        }
        Debug.Log("ここまで抜けた");
    }
   
}
