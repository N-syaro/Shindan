using UnityEngine;
using UnityEngine.SceneManagement;

public class StillPopUp : MonoBehaviour
{
    [SerializeField]
    TalkDelay T_deray;
    [Header("スチルイメージ参照")]
    public GameObject StillImage;
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
            case "JP":
                {
                    if (T_deray.currentText =="小さなラクダみたいなマスコットが話しかけてくる。")
                    {//後で色変え処理を書きたい
                        StillImage.SetActive(true);
                    }
                    else if(T_deray.currentText =="（こぶりボン？の話に耳を傾けた。）")
                    {
                        StillImage.SetActive(false);
                    }
                    break;
                }
         
        }  
    }
}
