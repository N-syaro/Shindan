using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Actionsuchiru : MonoBehaviour
{
    public TalkDelay talkDelay;
    public Image image;

    private CanvasGroup canvasGroup;
    private bool hasShown = false;

    private void Start()
    {
        canvasGroup = image.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = image.gameObject.AddComponent<CanvasGroup>();
        }

        image.gameObject.SetActive(false);
        canvasGroup.alpha = 0f;

    }

    private void Update()
    {
        if (hasShown) return;

        if (talkDelay.currentText == "小さなラクダみたいなマスコットが話しかけてくる。"|| talkDelay.currentText == "そう言って、ドアの前で一度だけ立ち止まる。"  || talkDelay.currentText == "スピーカーが低く震え、本が一冊落ちてきた。")
        {
            hasShown = true;
            StartCoroutine(ShowImage());
        }

        if (talkDelay.currentText == "次の言葉が、刃物のような実体として僕の方に目掛けて降ってきた。"||talkDelay.currentText == "「相談ありがとうございました。」" || talkDelay.currentText == "ふと僕が見上げると、")
        {
            hasShown = false;
            image.gameObject.SetActive(false);
        }
    }

    IEnumerator ShowImage()
    {
        image.gameObject.SetActive(true);
        
        float duration = 1f;
        float time = 0f;

        image.transform.localScale = Vector3.one * 1.08f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
            image.transform.localScale = Vector3.Lerp(Vector3.one * 1.08f, Vector3.one, t);
            yield return null;

        }
    }

}
