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

    void Start()
    {
        //省略：LogボタンのクリックでToggleLogが動作するようにLogボタンの生成・配置・クリックイベントの登録を行う
    }


    //表示なども省略(Logボタンの挙動も追加する

    public void ToggleLog()
    {
        // GameManager.Instance.gameUpdateManager.TurnOnLogMode(); //ログモードに切り替える
        _backlogInstance = Instantiate(backlogPrebab, backlogDisplay.transform); //バックログを生成する
        _isActiveLog = !_isActiveLog; // 状態を切り替える
                                      // DisplaySprite(); // ボタンの表示を更新
    }

    public void TurnOffLog()
    {
        _isActiveLog = false; // 状態を切り替える
                              //   DisplaySprite(); // ボタンの表示を更新

    }
}
