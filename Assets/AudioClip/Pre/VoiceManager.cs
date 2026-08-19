using UnityEngine;
using UnityEngine.Audio;

public class VoiceManager : MonoBehaviour
{
    

    //Voiceの登録場所(仮)
    public AudioClip[] voiceClips;

    //Voiceの登録場所(仮)
    public AudioClip[] voiceClipsTwo;

    //現在流れているVoice
    [SerializeField] AudioSource voiceSourceOne;

    //現在流れているVoice
    [SerializeField] AudioSource voiceSourceTwo;

    //オーディオミキサー
    [SerializeField] AudioMixer audioMixer;


    //登録されたボイスを流す
    public void voiceChangeOne(int voiceCount)
    {
        voiceStopOne();
        voiceSourceOne.PlayOneShot(voiceClips[voiceCount]);
    }

    //Voice停止
    public void voiceStopOne()
    {
        voiceSourceOne.Stop();
    }


    //登録されたボイスを流す
    public void voiceChangeTwo(int voiceCount)
    {
        voiceStopTwo();
        voiceSourceTwo.PlayOneShot(voiceClipsTwo[voiceCount]);
    }

    //Voice停止
    public void voiceStopTwo()
    {
        voiceSourceTwo.Stop();
    }
}
