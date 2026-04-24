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

    [SerializeField] AudioVolumeManager volumeManager;


    public static AudioSourceManager audioSInstance
    {
        get; private set;
    }



    

    void Awake()
    {
        if (audioSInstance == null)
        {
            audioSInstance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }

    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            volumeManager.bgmOneSwap();
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            volumeManager.bgmTwoSwap();
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            bgmChangeOne(0);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            bgmChangeOne(1);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            bgmChangeTwo(2);
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            bgmChangeTwo(3);
        }


    }




    //ìoò^Ç≥ÇÍÇΩBGMÇó¨Ç∑
    public void bgmChangeOne(int bgmCount)
    {
        bgmSourceOne.Stop();
        bgmSourceOne.clip = bgmClips[bgmCount];
        bgmSourceOne.Play();
    }
    public void bgmChangeTwo(int bgmCount)
    {
        bgmSourceTwo.Stop();
        bgmSourceTwo.clip = bgmClips[bgmCount];
        bgmSourceTwo.Play();
    }


    //ìoò^Ç≥ÇÍÇΩSEÇó¨Ç∑
    public void seChange(int seCount)
    {
        seSource.Stop();
        //seSource.clip = seClips[seCount];
        seSource.PlayOneShot(seClips[seCount]);
    }

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



}