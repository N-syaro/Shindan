using Unity.VisualScripting;
using UnityEngine;

public class DisplayMenu : MonoBehaviour
{
    [SerializeField] private GameObject backlogDisplay; 
    [SerializeField] private GameObject backlogPrebab; 
    [SerializeField] private Sprite _logButtonInactiveSprite;
    [SerializeField] private Sprite _logButtonActiveSprite;
    private bool _isActiveLog = false;
    private GameObject _logButtonInstance;
    private GameObject _backlogInstance;
    [Header("スクリプト参照")]
    [SerializeField]
    public TalkDelay talkDelay;
    void Start()
    {
        //省略：LogボタンのクリックでToggleLogが動作するようにLogボタンの生成・配置・クリックイベントの登録を行う
    }



    private void Update()
    {
        //デバッグ用コード
        if (Input.GetKeyDown(KeyCode.A/* Keypad0*/)) 
        {
            ToggleLog();
        }
        if (Input.GetKeyDown(KeyCode.S/*Keypad1*/))
        {
           TurnOffLog();
        }
    }

    public void ToggleLog()
    {
        talkDelay.TurnBacklogMode();
        _backlogInstance = Instantiate(backlogPrebab, backlogDisplay.transform); //バックログを生成する
        _isActiveLog = !_isActiveLog; // 状態を切り替える
                                      // DisplaySprite(); // ボタンの表示を更新
    }

    public void TurnOffLog()
    {
        talkDelay.TurnBacklogMode();
        _isActiveLog = false; // 状態を切り替える
                              //   DisplaySprite(); // ボタンの表示を更新

    }
}
