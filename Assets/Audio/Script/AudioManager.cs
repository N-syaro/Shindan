using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //オーディオミキサー
    [SerializeField] AudioMixer audioMixer;
    //マスターオーディオ用スライダー
    [SerializeField] Slider mastarSlider;
    //BGM用スライダー
    [SerializeField] Slider bgmSlider;
    //SE用スライダー
    [SerializeField] Slider seSlider;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void SetMaster(float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }
    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }
}
