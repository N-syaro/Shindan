 using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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
        Application.Quit();//アプリケーションの終了
        #if UNITY_EDITOR//unityエディターの再生停止
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void JapaneseButton(/*string*/)
    {
        //日本語でゲームを開始
        //SceneManager.LoadScene();
    }

    public void EnglishButton(/*string*/)
    {
        //英語でゲームを開始
        //SceneManager.LoadScene();
    }

    public void CancelButton()
    {
        //タイトル画面を表示
        languageCanvas.SetActive(false);
        titleCanvas.SetActive(true);
    }
}
