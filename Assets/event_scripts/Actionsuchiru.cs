using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

public class Actionsuchiru : MonoBehaviour
{
    public TalkDelay talkDelay;
    public Image image;
    [System.Serializable]
    public class TextImagePair
    { 
        public string text;
        public Sprite sprite;
    }

    public List<TextImagePair>imageList;

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
        if (!hasShown)
        {
            foreach (TextImagePair pair in imageList)
            {
                if (talkDelay.currentText == pair.text)
                {
                    image.sprite = pair.sprite;
                    hasShown = true;
                    StartCoroutine(ShowImage());
                    
                    break;
                }
            }
        }
        if (talkDelay.currentText == "次の言葉が、刃物のような実体として僕の方に目掛けて降ってきた。" || talkDelay.currentText == "「相談ありがとうございました。」" || talkDelay.currentText == "ふと僕が見上げると、")
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
