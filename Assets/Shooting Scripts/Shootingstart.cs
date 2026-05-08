using UnityEngine;
using System.Collections;

public class Shootingstart : MonoBehaviour
{
    private RectTransform rectTransform;
    public TalkDelay talkDelay;
    public GameObject[] targetObject;

    public float fallDuration = 2.0f;
    public float startY = 1000f;
    public float endY = 0f;
    public float maxcount = 11;
    private bool hasFallen = false;
    private int caunt = 0;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        caunt =targetObject.Length;
        
    }

    private void Update()
    {

        if (talkDelay.count >= maxcount&!hasFallen)
        {
            hasFallen = true;
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
            for (int i = 0; i < caunt; i++)
            {
                targetObject[i].SetActive(true);
            }
        }
    }
}