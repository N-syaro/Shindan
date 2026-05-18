using Unity.VisualScripting;
using UnityEngine;

public class BGMLoop : MonoBehaviour
{
   public AudioSource audioSource;
    public TalkDelay talkDelay;
    public AudioClip nextBGM;

    private bool changed = false;

    void Update()
    {
        if (talkDelay.currentText.Contains("‚ ‚ ‚ ‚ ") && !changed)//‚ ‚ ‚ ‚ ‚Ì‚Æ‚±‚ë‚ğØ‚è‘Ö‚í‚éŠ‚É
        {
            changed = true;

            audioSource.clip = nextBGM;
            audioSource.Play();
        }

    }

}
