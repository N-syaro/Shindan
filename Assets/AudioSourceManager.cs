using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceManager : MonoBehaviour
{
    //BGMÇÃìoò^èÍèä
    public AudioClip[] bgmClips;
    //SEÇÃìoò^èÍèä
    public AudioClip[] seClips;
    //åªç›ó¨ÇÍÇƒÇ¢ÇÈBGM
    [SerializeField] AudioSource bgmSourceOne;
    //åªç›ó¨ÇÍÇƒÇ¢ÇÈBGM
    [SerializeField] AudioSource bgmSourceTwo;

    //åªç›ó¨ÇÍÇƒÇ¢ÇÈSE
    [SerializeField] AudioSource seSource;



    public static AudioSourceManager audioInstance
    {
        get; private set;
    }



    public static AudioSource bgmInstance
    {
        get; private set;
    }


    
    public static AudioSource seInstance
    {
        get; private set;
    }


    void Awake()
    {
        if (audioInstance != null)
        {
            Destroy(this);
            return;
        }
        audioInstance = this;
        DontDestroyOnLoad(this);

        if (bgmInstance != null)
        {
            Destroy(bgmSourceOne);
            return;
        }
        bgmInstance = bgmSourceOne;
        DontDestroyOnLoad(bgmSourceOne);

        if (seInstance != null)
        {
            Destroy(seSource);
            return;
        }
        seInstance = seSource;
        DontDestroyOnLoad(seSource);
    }








    //ìoò^Ç≥ÇÍÇΩBGMÇó¨Ç∑
    public void bgmChange(int bgmCount)
    {
        bgmSourceOne.Stop();
        bgmSourceOne.clip = bgmClips[bgmCount];
        bgmSourceOne.Play();
    }

    //ìoò^Ç≥ÇÍÇΩSEÇó¨Ç∑
    public void seChange(int seCount)
    {
        seSource.Stop();
        //seSource.clip = seClips[seCount];
        seSource.PlayOneShot(seClips[seCount]);
    }

    //BGMí‚é~
    public void bgmStop()
    {
        bgmSourceOne.Stop();
    }

    //SEí‚é~
    public void seStop()
    {
        seSource.Stop();
    }



}