using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TalkController : MonoBehaviour
{
    //------  参照  ------
    [Header("UI参照")]
    [SerializeField]public GameObject TalkUI;
    [SerializeField] Text Talktext;
    [SerializeField] Text Nametext;
    [SerializeField] GameObject P_Image;
    [SerializeField] GameObject E_Image;
   [SerializeField] Image PlayerImage;
   [SerializeField] Image FriendsImage;
    [Header("機能参照")]
  　 // [SerializeField] GameManager gameManager;　仮消し
    [SerializeField] TalkDelay conttext;
    [SerializeField] GameManager gamemanager;
    
    [Header("データ参照")]//スクリプタブル    
    [SerializeField] MakeConversation Textdata;//会話データ
   // [SerializeField] Chara_data NPCData;//NPCのデータ
   // [SerializeField, Header("プレイヤー")] Chara_data Player_Data;//プレイヤーのデータ
    //[SerializeField] ButtonAdd_ a;*/
    public enum TextMeshProMode { TextMeshPro, TextMeshProUGUI, TMP_Text }

    private List<(string Name,Sprite p_image, string Text)> backlogLogTextList = new();

    private IEnumerator colti;
    //------  変数  ------
  
    int num;
    private void Awake()
    {
        TalkUI.SetActive(false);
    }
    private void Start()
    {
        
       // Manage();
    }
 

    public void SetObject(MakeConversation d)
    {
        if (d == null) { Debug.LogWarning("TextDataNull"); }
       // if (c == null) { Debug.LogWarning("CharaDataNull"); }
        Textdata = d;
        //NPCData = c;
        //gameManager.c(false);//仮消し    
        Talk();
    }
    void Talk()
    {
        StartCoroutine(Manage());
    }
    public void OnSpase(InputAction.CallbackContext context)
    {
        if (context.performed)
        {  
            conttext.SKip();
        }      
    }
    public void CTalk(MakeConversation data)
    {
        StopAllCoroutines();
        colti = null;
        //gameManager.c(false);仮消し
        StartCoroutine(CCOL(data.Datas, data.UseImage_));
    }
    IEnumerator CCOL(Setting_Text_Data[] data, bool i)
    {
        TalkUI.SetActive(true);
        colti = col(data, i);
        yield return StartCoroutine(colti);
    }
    IEnumerator Manage()//会話開始
    {
        TalkUI.SetActive(true);
     //  if (Player_Data.Image != null) { PlayerImage.sprite = Player_Data.Image[0]; }
     //  if (NPCData.Image != null) { FriendsImage.sprite = NPCData.Image[0]; }
        colti = col(Textdata.Datas, Textdata.UseImage_);
        yield return StartCoroutine(colti);
        gamemanager.Talkend = true;
        TalkUI.SetActive(false);
        //gameManager.c(true);仮消し
        Debug.Log("cclo");
        yield break;
    }

    IEnumerator col(Setting_Text_Data[] data,bool usei)
    {

        //イラスト表示-------------------------------------------------------------------------
        foreach (var item in data)
        {
            
            if (usei)
            {
                Nametext.enabled = true;
                PlayerImage.enabled = true;
                FriendsImage.enabled = true;
                PlayerImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
                FriendsImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
              
                string charaName = item.Talking_chara?.Name ?? "";
                Nametext.text = charaName;
                bool hasValidImage = item.Talking_chara?.Image != null && item.Talking_chara.Image.Length > item.CHImageNum_ &&item.Talking_chara.Image[item.CHImageNum_] != null;
                if (item.Side)
                {
                    if (hasValidImage)
                    {
                        PlayerImage.sprite = item.Talking_chara.Image[item.CHImageNum_];
                        PlayerImage.color = new Color(1, 1, 1, 1);
                        backlogLogTextList.Add((charaName, item.Talking_chara.Image[2/*2は仮*/], item.TextData));
                    }
                    else
                    {
                        PlayerImage.enabled = false; // 画像なければ非表示
                        Nametext.enabled = false;
                        backlogLogTextList.Add((charaName, PlayerImage.sprite, item.TextData));
                    }
                  //  backlogLogTextList.Add((charaName, item.TextData));
                }
                else
                {
                    if (hasValidImage)
                    {
                        FriendsImage.sprite = item.Talking_chara.Image[item.CHImageNum_];
                        FriendsImage.color = new Color(1, 1, 1, 1);
                        backlogLogTextList.Add((charaName, FriendsImage.sprite, item.TextData));
                    }
                    else
                    {
                        FriendsImage.enabled = false; // 画像なければ非表示
                        Nametext.enabled = false;
                        backlogLogTextList.Add((charaName, FriendsImage.sprite, item.TextData));
                    }
                   // backlogLogTextList.Add((charaName, item.TextData));
                }
            }
            else
            {
                PlayerImage.enabled = false;
                FriendsImage.enabled = false;

                backlogLogTextList.Add(("", null,item.TextData));
            }
        
            yield return StartCoroutine(conttext.TextActive(Talktext, item.TextData));
　　　　　
        }
        yield break;
    }

    private void Update()
    {
        Debug.Log("バックログ件数: " + backlogLogTextList.Count);
        if (Input.GetKeyDown(KeyCode.W/*KeypadEnter*/))
        {
            StartCoroutine(Manage());
        }  
    }

    public List<(string Name, Sprite p_image, string Text)> GetBacklogList()
    {
        // 件数を表示
        Debug.Log("バックログ件数: " + backlogLogTextList.Count);

        // 中身を1件ずつ表示
        for (int i = 0; i < backlogLogTextList.Count; i++)
        {
            Debug.Log($"[{i}] Name: {backlogLogTextList[i].Name} / Text: {backlogLogTextList[i].Text}");
        }
        return backlogLogTextList;
    }
    /*  public void c(bool a)  gamemanagerに記入（UI操作の切り替え)
      {
          if (a)
          {
              Ui.enabled = !a;
              player.enabled = a;
          }
          else
          {
              player.enabled = a;
              Ui.enabled = !a;
          }

      
      }*/
}
