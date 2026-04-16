 using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //タイトルキャンバス
    [SerializeField] GameObject titleCanvas;
    //言語キャンバス
    [SerializeField] GameObject languageCanvas;

    private string gameLanguage;


    public void StartButton(string gameLanguage)
    {
        SceneManager.LoadScene(gameLanguage);
    }
    public void LanguageButton()
    {
        //言語選択画面を表示
        languageCanvas.SetActive(true);
        titleCanvas.SetActive(false);
    }


    public void EndButton()
    {
        //ゲームを終了
        Application.Quit();//アプリケーションの終了
        #if UNITY_EDITOR//unityエディターの再生停止
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void JapaneseButton()
    {
        //日本語に設定
        gameLanguage = "JP";
    }

    public void EnglishButton()
    {
        //英語に設定
        gameLanguage = "EN";
    }

    public void CancelButton()
    {
        //タイトル画面を表示
        languageCanvas.SetActive(false);
        titleCanvas.SetActive(true);
    }
}
