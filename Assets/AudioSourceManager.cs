using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceManager : MonoBehaviour
{
    //BGM‚Ì“o˜^êŠ
    public AudioClip[] bgmClips;
    //SE‚Ì“o˜^êŠ
    public AudioClip[] seClips;
    //Œ»İ—¬‚ê‚Ä‚¢‚éBGM
    [SerializeField] AudioSource bgmSource;
    //Œ»İ—¬‚ê‚Ä‚¢‚éSE
    [SerializeField] AudioSource seSource;


    //“o˜^‚³‚ê‚½BGM‚ğ—¬‚·
    public void bgmChange(int bgmCount)
    {
        bgmSource.Stop();
        bgmSource.clip = bgmClips[bgmCount];
        bgmSource.Play();
    }

    //“o˜^‚³‚ê‚½SE‚ğ—¬‚·
    public void seChange(int seCount)
    {
        seSource.Stop();
        //seSource.clip = seClips[seCount];
        seSource.PlayOneShot(seClips[seCount]);
    }

    //BGM’â~
    public void bgmStop()
    {
        bgmSource.Stop();
    }

    //SE’â~
    public void seStop()
    {
        bgmSource.Stop();
    }



}