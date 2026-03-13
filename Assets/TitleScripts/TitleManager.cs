using UnityEngine;
using UnityEngine.Audio;

public class TitleManager : MonoBehaviour
{
    //タイトルキャンバス
    [SerializeField] GameObject titleCanvas;
    //言語キャンバス
    [SerializeField] GameObject languageCanvas;

    public void StartButton()
    {
        //言語選択画面を表示
        languageCanvas.SetActive(true);
        titleCanvas.SetActive(false);
    }

    public void EndButton()
    {
        //ゲームを終了
    }

    public void JapaneseButton()
    {
        //日本語でゲームを開始
    }

    public void EnglishButton()
    {
        //英語でゲームを開始

    }

    public void CancelButton()
    {
        //タイトル画面を表示
        languageCanvas.SetActive(false);
        titleCanvas.SetActive(true);
    }
}
