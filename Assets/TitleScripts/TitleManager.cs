 using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //タイトルキャンバス
    [SerializeField] GameObject titleCanvas;
    //言語キャンバス
    [SerializeField] GameObject languageCanvas;
    //日本語確認用テキスト
    [SerializeField] GameObject jpText;
    //英語確認用テキスト
    [SerializeField] GameObject enText;
    //選択した言語
    private string gameLanguage = "JP";

    public FadeOutIn fadeout;

    public AudioSourceManager sourceManager;

    private void Awake()
    {
        titleCanvas.SetActive(true);
        languageCanvas.SetActive(false);
        jpText.SetActive(true);
        enText.SetActive(false);

        //fade = GetComponent<FadeOutIn>();
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 新しいシーンが読み込まれたときに自動で実行される
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 新しいシーン内から「FadeOutIn」コンポーネントが付いているオブジェクトを探す
        fadeout = FindFirstObjectByType<FadeOutIn>();

        sourceManager = FindFirstObjectByType<AudioSourceManager>();

       
    }

    public void StartButton(string sceneName)
    {
        sceneName = gameLanguage;

        

        sourceManager.seChange(3);

        fadeout.fadeOutIn(0f, 0.2f, 0.2f);


        SceneManager.LoadScene(sceneName);

        

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
        jpText.SetActive(true);
        enText.SetActive(false);
    }

    public void EnglishButton()
    {
        //英語に設定
        gameLanguage = "EN";
        jpText.SetActive(false);
        enText.SetActive(true);
    }

    public void CancelButton()
    {
        //タイトル画面を表示
        languageCanvas.SetActive(false);
        titleCanvas.SetActive(true);
    }

    public void BonusButton(string Bonus)
    {
        SceneManager.LoadScene(Bonus);
    }
}
