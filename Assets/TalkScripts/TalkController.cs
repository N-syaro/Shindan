using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEditor.Rendering.LookDev;

public class TalkController : MonoBehaviour
{
    //------  参照  ------
    [Header("UI参照")]
    [SerializeField] GameObject TalkUI;
    [SerializeField] Text Talktext;
    [SerializeField] Text Nametext;
   // [SerializeField] Text left;
    //[SerializeField] Text right;
    //[SerializeField] Image PlayerImage;
   // [SerializeField] Image FriendsImage;
    [Header("機能参照")]
  　 // [SerializeField] GameManager gameManager;　仮消し
    [SerializeField] TalkDelay conttext;

    
    [Header("データ参照")]//スクリプタブル    
    [SerializeField] MakeConversation Textdata;//会話データ
    [SerializeField] Chara_data NPCData;//NPCのデータ
    [SerializeField, Header("プレイヤー")] Chara_data Player_Data;//プレイヤーのデータ
    //[SerializeField] ButtonAdd_ a;*/
    public enum TextMeshProMode { TextMeshPro, TextMeshProUGUI, TMP_Text }

    private IEnumerator colti;
    //------  変数  ------
  
    int num;
    private void Start()
    {
        TalkUI.SetActive(false);
        Manage();
    }
 
    public void SetObject(MakeConversation d, Chara_data c)
    {
        if (d == null) { Debug.LogWarning("TextDataNull"); }
        if (c == null) { Debug.LogWarning("CharaDataNull"); }
        Textdata = d;
        NPCData = c;
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
        colti = col(data, NPCData, i);
        yield return StartCoroutine(colti);
    }
    IEnumerator Manage()
    {
        TalkUI.SetActive(true);
      //  if (Player_Data.Image != null) { PlayerImage.sprite = Player_Data.Image[0]; }
//if (NPCData.Image != null) { FriendsImage.sprite = NPCData.Image[0]; }
        colti = col(Textdata.Datas, NPCData, Textdata.UseImage_);
        yield return StartCoroutine(colti);
        TalkUI.SetActive(false);
        //gameManager.c(true);仮消し
        Debug.Log("cclo");
        yield break;
    }

    IEnumerator col(Setting_Text_Data[] data, Chara_data charaData, bool usei)
    {
        //イラスト表示-------------------------------------------------------------------------
        foreach (var item in data)
        {/*
            if (usei)
            {
                PlayerImage.enabled = true;
                FriendsImage.enabled = true;
                PlayerImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
                FriendsImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
                if (item.Side)
                {
                    PlayerImage.sprite = Player_Data.Image[item.CHImageNum_];
                    Nametext.text = Player_Data.Name;
                    PlayerImage.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    FriendsImage.sprite = charaData.Image[item.CHImageNum_];
                    Nametext.text = charaData.Name;
                    FriendsImage.color = new Color(1, 1, 1, 1);
                }
            }
            else
            {
                PlayerImage.enabled = false;
                FriendsImage.enabled = false;
            }
        */
            yield return StartCoroutine(conttext.TextActive(Talktext, item.TextData));
　　　　　
        }
        yield break;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Manage());
        }  
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
