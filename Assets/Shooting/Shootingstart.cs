using UnityEngine;
using System.Collections;

public class UIFall : MonoBehaviour
{
    private RectTransform rectTransform;

    public float fallDuration = 2.0f;
    public float startY = 1000f;
    public float endY = 0f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void StartFall()
    {
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        Vector2 startPos = new Vector2(rectTransform.anchoredPosition.x, startY);
        Vector2 endPos = new Vector2(rectTransform.anchoredPosition.x, endY);

        float elapsed = 0;

        while (elapsed < fallDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fallDuration;

            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, t);

            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
    }
}