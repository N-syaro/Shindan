using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AudioVolumeManager : MonoBehaviour
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


   

    void Start()
    {
        menuCanvas.SetActive(false);
        //BGM
        InitializeSlider("BGM", bgmSlider, bgmText);
        //SE
        InitializeSlider("SE", seSlider, seText);
        //CV
        InitializeSlider("CV", voiceSlider, voiceText);
    }

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
            slider.value = Mathf.Pow(10, volumeDB / 20);
            UpdateText(slider, text);
        }
    }
    // 各メソッドをUIのOnValueChangedから呼ぶ
    public void SetBGM(float value) => SetVolume("BGM", value, bgmText);
    public void SetSE(float value) => SetVolume("SE", value, seText);
    public void SetCV(float value) => SetVolume("CV", value, voiceText);
    private void SetVolume(string name, float value, Text text)
    {
        // 0だとLog10がエラーになるため、Mathf.Clampで微小な値を確保
        float db = Mathf.Log10(Mathf.Max(0.0001f, value)) * 20;
        audioMixer.SetFloat(name, db);

        UpdateText(null, text, value);
    }
   
    private void UpdateText(Slider slider, Text text, float value = -1)
    {
        float val = value < 0 ? slider.value : value;
        //%表示にする
        text.text = Mathf.FloorToInt(val * 100).ToString() + "%";
        
    }


    public void bgmOneSwap()
    {
        //BGM1が聞こえるように
        audioMixer.SetFloat("BGM_1", 0f);
        audioMixer.SetFloat("BGM_2", -80f);
    }
    public void bgmTwoSwap()
    {
        //BGM2が聞こえるように
        audioMixer.SetFloat("BGM_1", -80f);
        audioMixer.SetFloat("BGM_2", 0f);
    }


    public void TitleButton(string Title)
    {
        menuCanvas.SetActive(false);
        isMenuOpen = false;
        //タイトル画面に戻る
        SceneManager.LoadScene(Title);
        
    }
    
}
