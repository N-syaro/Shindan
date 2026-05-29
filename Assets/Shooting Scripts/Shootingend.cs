using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shootingend : MonoBehaviour
{
    public Image blackFadeImage;

    public float fadeOutDuration = 1.5f;
    public float fadeInDuration = 1.5f;

    public GameObject targetUI;
    public GameObject player;
    //public Shootingcom spawner;
    private bool isFading = false;
    private void Start()
    {
        Color c = blackFadeImage.color;
        c.a = 0;
        blackFadeImage.color = c;

        Startfade();
    }
    public void Startfade()
    {
        
        if (isFading) return;

        isFading = true;

        StartCoroutine(DelayedFadeSequence());
    }
    IEnumerator DelayedFadeSequence()
    {

        //// ここで6秒待機してからフェードシーケンスを開始
        yield return new WaitForSeconds(6f);  // 6秒待機
        yield return StartCoroutine(FadeSequence());
    }
    IEnumerator FadeSequence()
    {
        //// フェードアウトしてUIを上に移動させるシーケンス
        yield return StartCoroutine(FadeToBlack());
        if (targetUI != null)
        {
            yield return StartCoroutine(MoveUpAndHide(targetUI));
        }


        yield return StartCoroutine(FadeFromBlack());
    }

    IEnumerator FadeToBlack()
    {
        //// フェードアウトして画面を黒くするシーケンス
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
        Vector2 end = start + new Vector2(0, 1100f);

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            rt.anchoredPosition = Vector2.Lerp(start, end, t);
            yield return null;
        }
        player.SetActive(false);
        targetUI.SetActive(false);
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