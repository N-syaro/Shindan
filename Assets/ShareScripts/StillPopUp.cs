using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StillPopUp : MonoBehaviour
{
    [SerializeField]
    TalkDelay T_deray;
    [Header("スチルイメージ参照")]
    public GameObject StillImage;
    public Image Still_Image;
    public Sprite[] Still_Sprite;
    private string Scenename;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scenename = SceneManager.GetActiveScene().name;
        StillImage = GameObject.Find("StillImage");
        if(StillImage != null)
        {
            StillImage.SetActive(false);
        }
        else
        {
            Debug.Log("スチルイメージがnullです");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //スチル立ち上げ処理＊後々各シーンごとに処理を記入
        switch(Scenename)
        {
            case "JP"://導入
                {
                    if (T_deray.currentText =="小さなラクダみたいなマスコットが話しかけてくる。")
                    {//後で色変え処理を書きたい
                        Still_Image .color = new Color(1, 1, 1, 1);
                        Still_Image.sprite = Still_Sprite[0];
                        StillImage.SetActive(true);
                    }
                    else if(T_deray.currentText =="（こぶりボン？の話に耳を傾けた。）")
                    {
                        StillImage.SetActive(false);
                    }
                    break;
                }
            case "Bad END"://バッドエンド
                {
                    if (T_deray.currentText == "スピーカーが低く震え、本が一冊落ちてきた。")
                    {//後で色変え処理を書きたい
                        Still_Image.color = new Color(1, 1, 1, 1);
                        Still_Image.sprite = Still_Sprite[0];
                        StillImage.SetActive(true);
                    }
                    else if (T_deray.currentText == "一冊、また一冊。")
                    {
                        Still_Image.sprite = Still_Sprite[1];
                    }
                    else if (T_deray.currentText == "僕は気持ちに寄り添えている、つもりだった。")
                    {
                        StillImage.SetActive(false);
                    }
                    break;
                }
            case "END Credits":
                {
                    if (T_deray.currentText == "・・・・・ちゃんと、話してから決めます。")
                    {//後で色変え処理を書きたい
                        Still_Image.color = new Color(1, 1, 1, 1);
                        Still_Image.sprite = Still_Sprite[0];
                        StillImage.SetActive(true);
                    }
                    else if (T_deray.currentText == "・・・・・解決だ～")
                    {
                        StillImage.SetActive(false);
                    }
                    break;
                }
         
        }  
    }
}
