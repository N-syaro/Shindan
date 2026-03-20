using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shootingstart : MonoBehaviour
{
    private RectTransform rectTransform;

    public float fallDuration = 2.0f;
    public float fadeDuration = 1.5f;
    public float fadeInDuration = 1.5f;

    private bool isMoving = false;

   
    public Image blackFadeImage;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        TriggerFalling();
    }

    public void TriggerFalling()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(FallAndFade());
        }
    }

    IEnumerator FallAndFade()
    {
        yield return new WaitForSeconds(2.0f);

        
        Vector2 startPos = new Vector2(rectTransform.anchoredPosition.x, 1000);
        Vector2 endPos = new Vector2(rectTransform.anchoredPosition.x, 0f);

        float elapsed = 0;

        while (elapsed < fallDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fallDuration;

            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, t);

            yield return null;
        }

        rectTransform.anchoredPosition = endPos;

        
        yield return StartCoroutine(FadeToBlack());

        yield return StartCoroutine(FadeFromBlack());

        gameObject.SetActive(false);


        isMoving = false;
    }

    IEnumerator FadeToBlack()
    {
        float elapsed = 0;
        Color color = blackFadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;

            color.a = Mathf.Lerp(0, 1, t);
            blackFadeImage.color = color;

            yield return null;
        }

        color.a = 1;
        blackFadeImage.color = color;
    }
    IEnumerator FadeFromBlack()
    {
        float elapsed = 0;
        Color color = blackFadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;

            color.a = Mathf.Lerp(1, 0, t);
            blackFadeImage.color = color;

            yield return null;
        }

        color.a = 0;
        blackFadeImage.color = color;
    }
}