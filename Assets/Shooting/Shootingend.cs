using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shootingend : MonoBehaviour
{
    public Image blackFadeImage;

    public float fadeOutDuration = 1.5f;
    public float fadeInDuration = 1.5f;

    public GameObject targetUI;

    public Shoootingcom spawner;
    private bool isFading = false;
    void Start()
    {
        Color c = blackFadeImage.color;
        c.a = 0;
        blackFadeImage.color = c;
     
 
    }
    public void Startfade()
    {
        if (isFading) return;

        isFading = true;

        StartCoroutine(FadeSequence());
    }
   
    IEnumerator FadeSequence()
    {
        //yield return StartCoroutine(FadeToBlack());
        if (targetUI != null)
        {
            yield return StartCoroutine(MoveUpAndHide(targetUI));
        }
        

       
        //yield return StartCoroutine(FadeFromBlack());
    }

    IEnumerator FadeToBlack()
    {
        float elapsed = 0;
        Color color = blackFadeImage.color;

        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeOutDuration;

            color.a = Mathf.Lerp(0, 1, t);
            blackFadeImage.color = color;

            yield return null;
        }

        color.a = 1;
        blackFadeImage.color = color;
    }
    IEnumerator MoveUpAndHide(GameObject targetUI)
    {
        RectTransform rt = targetUI.GetComponent<RectTransform>();

        float time = 0;
        float duration = 2f;

        Vector2 start = rt.anchoredPosition;
        Vector2 end = start + new Vector2(0,1100f);

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            rt.anchoredPosition = Vector2.Lerp(start, end, t);
            yield return null;
        }
    }


    IEnumerator FadeFromBlack()
    {
        float elapsed = 0;
        Color color = blackFadeImage.color;

        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeInDuration;

            color.a = Mathf.Lerp(1, 0, t);
            blackFadeImage.color = color;

            yield return null;
        }

        color.a = 0;
        blackFadeImage.color = color;
    }
}