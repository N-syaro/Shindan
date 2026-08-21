using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    //メニューキャンバス
    [SerializeField] GameObject menuCanvas;

    //オーディオミキサー
    [SerializeField] AudioMixer audioMixer;

    //メニュー表示フラグ(メニューかキャンバスを必ず非表示に）
    public bool isMenuOpen = false;

    //BGM用スライダー
    [SerializeField] Slider bgmSlider;
    //SE用スライダー
    [SerializeField] Slider seSlider;
    //Voice用スライダー
    [SerializeField] Slider voiceSlider; 

    //BGM用テキスト
    [SerializeField] Text bgmText;
    //SE用テキスト
    [SerializeField] Text seText;
    //Voice用テキスト
    [SerializeField] Text voiceText;

    public static MenuManager menuInstance = null;

    public FadeOutIn fadeout;

    //BGMの登録場所
    public AudioClip[] bgmClips;
    //SEの登録場所
    public AudioClip[] seClips;

    

    //現在流れているBGM1
    [SerializeField] AudioSource bgmSourceOne;
    //現在流れているBGM2
    [SerializeField] AudioSource bgmSourceTwo;

    //現在流れているSE
    [SerializeField] AudioSource seSource;

    




    void Awake()
    {
        //ゲーム上に一つ以下しかないようにする
        if (menuInstance == null)
        {
            menuInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    IEnumerator Start()
    {
        menuCanvas.SetActive(false);
        //BGM
        InitializeSlider("BGM", bgmSlider, bgmText);
        //SE
        InitializeSlider("SE", seSlider, seText);
        //Voice
        InitializeSlider("Voice", voiceSlider, voiceText);
        audioMixer.SetFloat("BGM_1", 0f);
        audioMixer.SetFloat("BGM_2", -80f);



        //1フレーム待つ(消えてしまうオブジェクトを参照しないようにするため) 
        yield return null;


        fadeout = FindFirstObjectByType<FadeOutIn>();

    }


    //オーディオ関係----------------------------------------------------------------------------

    //登録されたBGMを流す
    public void bgmChangeOne(int bgmCount)
    {
        bgmStopOne();
        bgmSourceOne.clip = bgmClips[bgmCount];
        bgmSourceOne.Play();
    }
    public void bgmChangeTwo(int bgmCount)
    {
        bgmStopTwo();
        bgmSourceTwo.clip = bgmClips[bgmCount];
        bgmSourceTwo.Play();
    }


    //登録されたSEを流す
    public void seChange(int seCount)
    {
        seSource.PlayOneShot(seClips[seCount]);
    }

    
    



    //BGM停止
    public void bgmStopOne()
    {
        bgmSourceOne.Stop();
    }
    public void bgmStopTwo()
    {
        bgmSourceTwo.Stop();
    }

    //SE停止
    public void seStop()
    {
        seSource.Stop();
    }

    public void bgmSwap(int bgmSwapCount)
    {
        if (bgmSwapCount == 1)
        {
            //BGM1が聞こえるように
            audioMixer.SetFloat("BGM_1", 0f);
            audioMixer.SetFloat("BGM_2", -80f);
        }
        if (bgmSwapCount == 2)
        {
            //BGM2が聞こえるように
            audioMixer.SetFloat("BGM_1", -80f);
            audioMixer.SetFloat("BGM_2", 0f);
        }
        if(bgmSwapCount == 3)
        {
            bgmSourceOne.Stop();
            bgmSourceTwo.Stop();
        }
    }
    


    

    //-----------------------------------------------------


    //メニュー関連---------------------------------------------------------
    void Update()
    {
        // エスケープキーが押されたら
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }


    }
    public void ToggleMenu()
    {
        //メニューを閉じる
        if (isMenuOpen)
        {
            CloseMenu();
        }
        //メニューを開ける
        else
        {
            OpenMenu();
        }
    }
    // メニューを表示
    public void OpenMenu()
    {
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(true);
            isMenuOpen = true;
            // ゲームを一時停止
            Time.timeScale = 0f;

        }
        else { Debug.LogError("menuCanvasがインスペクターで設定されていません！"); }
    }
    // メニューを非表示
    public void CloseMenu()
    {
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
            isMenuOpen = false;
            // ゲームを再開
            Time.timeScale = 1f;

        }
    }


    private void InitializeSlider(string name, Slider slider, Text text)
    {
        // Mixerから現在のデシベルを取得し、スライダーの値(0-1)に逆換算して適用
        if (audioMixer.GetFloat(name, out float volumeDB))
        {
            float volumeValue = Mathf.Pow(10, volumeDB / 20);
            if (slider != null) slider.value = volumeValue;
            UpdateText(text, volumeValue);
        }
    }
    // 各メソッドをUIのOnValueChangedから呼ぶ
    public void SetBGM(float value) => SetVolume("BGM", value, bgmText);
    public void SetSE(float value) => SetVolume("SE", value, seText);
    public void SetVoice(float value) => SetVolume("Voice", value, voiceText);
    private void SetVolume(string name, float value, Text text)
    {
        // 0だとLog10がエラーになるため、Mathf.Clampで微小な値を確保
        float db = Mathf.Log10(Mathf.Max(0.0001f, value)) * 20;
        audioMixer.SetFloat(name, db);

        UpdateText(text, value);
    }

    private void UpdateText(Text text, float value)
    {
        //%表示にする
        if (text != null)
        {
            text.text = Mathf.FloorToInt(value * 100).ToString() + "%";
        }
        else
        {
            Debug.LogWarning("Textコンポーネントがアタッチされていません。");
        }

    }





    public void TitleButton(string Title)
    {
        Time.timeScale = 1f;
        menuCanvas.SetActive(false);
        isMenuOpen = false;

        if (fadeout != null)
        {
            fadeout.fadeOutIn(0f, 0.2f, 0.2f);
        }
        else
        {
            Debug.LogError("フェードオブジェクトがない");
        }

        bgmSwap(3);

        //タイトル画面に戻る
        SceneManager.LoadScene(Title);

    }

    //-----------------------------------------------------------------------------------------




}
