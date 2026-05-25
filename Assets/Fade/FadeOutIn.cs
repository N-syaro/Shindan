using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutIn : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeImage;

    [SerializeField]
    private CanvasGroup canvasGroup;

    

    private void Awake()
    {
        canvasGroup.alpha = 0f;

        fadeImage.gameObject.SetActive(false);
        
    }

    public void fadeOutIn(float outTime, float wait, float inTime)
    {
        StopAllCoroutines();
        StartCoroutine(startFadeOutIn(outTime, wait, inTime));
    }

    public void fadeOut(float outTime)
    {
        StopAllCoroutines();
        StartCoroutine(startFadeOut(outTime));
    }

    public void fadeIn(float wait, float inTime)
    {
        StopAllCoroutines();
        StartCoroutine(startFadeIn(wait, inTime));
    }

    IEnumerator startFadeOutIn(float outTime, float wait, float inTime)
    {
        yield return StartCoroutine(startFadeOut(outTime));

        yield return new WaitForSeconds(wait);

        yield return StartCoroutine(startFadeIn(0f, inTime));

        yield return null;
    }


    IEnumerator startFadeOut(float outTime)
    {
        fadeImage.gameObject.SetActive(true);


        float fadeOutSpeed = 1.0f / outTime;
        float currentAlpha = canvasGroup.alpha;



        while (currentAlpha < 1.0f)
        {
            currentAlpha += fadeOutSpeed * Time.deltaTime;
            canvasGroup.alpha = currentAlpha;
            yield return null;
        }
        canvasGroup.alpha = 1.0f;

        yield return null;

    }


    IEnumerator startFadeIn(float wait, float inTime)
    {

        


        if (wait > 0f)
        {
            yield return new WaitForSeconds(wait);
        }
        float fadeInSpeed = 1.0f / inTime;
        float currentAlpha = canvasGroup.alpha;

        while (currentAlpha > 0.0f)
        {
            currentAlpha -= fadeInSpeed * Time.deltaTime;
            canvasGroup.alpha = currentAlpha;
            yield return null;
        }
        canvasGroup.alpha = 0.0f;

        fadeImage.gameObject.SetActive(false);

    }
    

    
}
