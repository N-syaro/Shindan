using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceManager : MonoBehaviour
{
    //BGM‚Ì“o˜^êŠ
    public AudioClip[] bgmClips;
    //SE‚Ì“o˜^êŠ
    public AudioClip[] seClips;

    //Voice‚Ì“o˜^êŠ(‰¼)
    //public AudioClip[] voiceClips;

    //Œ»İ—¬‚ê‚Ä‚¢‚éBGM1
    [SerializeField] AudioSource bgmSourceOne;
    //Œ»İ—¬‚ê‚Ä‚¢‚éBGM2
    [SerializeField] AudioSource bgmSourceTwo;

    //Œ»İ—¬‚ê‚Ä‚¢‚éSE
    [SerializeField] AudioSource seSource;

    //Œ»İ—¬‚ê‚Ä‚¢‚éVoice
    //[SerializeField] AudioSource voiceSource;

    

    //g‚¢•û‚ÍƒMƒƒƒ‰ƒŠ[‚ÌƒtƒF[ƒhŠÖŒW‚ğQl‚É‚µ‚Ä‚­‚¾‚³‚¢



    //“o˜^‚³‚ê‚½BGM‚ğ—¬‚·
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


    //“o˜^‚³‚ê‚½SE‚ğ—¬‚·
    public void seChange(int seCount)
    {
        seSource.PlayOneShot(seClips[seCount]);
    }

    //“o˜^‚³‚ê‚½ƒ{ƒCƒX‚ğ—¬‚·
    /*
    public void voiceChange(int voiceCount)
    {
        voiceStop();
        voiceSource.PlayOneShot(voiceClips[voiceCount]);
    }
    */



    //BGM’â~
    public void bgmStopOne()
    {
        bgmSourceOne.Stop();
    }
    public void bgmStopTwo()
    {
        bgmSourceTwo.Stop();
    }

    //SE’â~
    public void seStop()
    {
        seSource.Stop();
    }

    //Voice’â~
    /*
    public void voiceStop()
    {
        voiceSource.Stop();
    }
    */
}