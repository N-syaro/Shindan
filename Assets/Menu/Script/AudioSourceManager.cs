using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceManager : MonoBehaviour
{
    //BGMÇÃìoò^èÍèä
    public AudioClip[] bgmClips;
    //SEÇÃìoò^èÍèä
    public AudioClip[] seClips;

    //VoiceÇÃìoò^èÍèä(âº)
    //public AudioClip[] voiceClips;

    //åªç›ó¨ÇÍÇƒÇ¢ÇÈBGM1
    [SerializeField] AudioSource bgmSourceOne;
    //åªç›ó¨ÇÍÇƒÇ¢ÇÈBGM2
    [SerializeField] AudioSource bgmSourceTwo;

    //åªç›ó¨ÇÍÇƒÇ¢ÇÈSE
    [SerializeField] AudioSource seSource;

    //åªç›ó¨ÇÍÇƒÇ¢ÇÈVoice
    //[SerializeField] AudioSource voiceSource;

    [SerializeField] AudioVolumeManager volumeManager;


    public static AudioSourceManager audioInstance = null;


    void Awake()
    {
        //êeéqä÷åWÇÉäÉZÉbÉg
        transform.SetParent(null);
        //ÉQÅ[ÉÄè„Ç…àÍÇ¬à»â∫ÇµÇ©Ç»Ç¢ÇÊÇ§Ç…Ç∑ÇÈ
        if (audioInstance == null)
        {
            audioInstance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }

    }

    


    //ìoò^Ç≥ÇÍÇΩBGMÇó¨Ç∑
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


    //ìoò^Ç≥ÇÍÇΩSEÇó¨Ç∑
    public void seChange(int seCount)
    {
        seSource.PlayOneShot(seClips[seCount]);
    }

    //ìoò^Ç≥ÇÍÇΩÉ{ÉCÉXÇó¨Ç∑
    /*
    public void voiceChange(int voiceCount)
    {
        voiceStop();
        voiceSource.PlayOneShot(voiceClips[voiceCount]);
    }
    */



    //BGMí‚é~
    public void bgmStopOne()
    {
        bgmSourceOne.Stop();
    }
    public void bgmStopTwo()
    {
        bgmSourceTwo.Stop();
    }

    //SEí‚é~
    public void seStop()
    {
        seSource.Stop();
    }

    //Voiceí‚é~
    /*
    public void voiceStop()
    {
        voiceSource.Stop();
    }
    */
}