using System.Collections;
using UnityEngine;

public class BgmLoop : MonoBehaviour
{
   public AudioSource audioSource;

    public  bool stopflag = false;

    private void Start()
    {
        StartCoroutine(PlayLoop());
    }

    IEnumerator PlayLoop()
    {
        audioSource.loop = true;
        audioSource.Play();

        yield return new WaitUntil(() => stopflag == true);
        //FindObjectOfType<BgmLoop>().stopflag = true;‚ğ³‰ğ‚É‘‚­

        audioSource.Stop();
    }


}
