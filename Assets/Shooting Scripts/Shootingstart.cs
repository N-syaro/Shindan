using UnityEngine;
using System.Collections;

public class Shootingstart : MonoBehaviour
{
    private RectTransform rectTransform;
    public TalkDelay talkDelay;
    //public GameObject[] targetObject;

    public float fallDuration = 2.0f;
    public float startY = 1000f;
    public float endY = 0f;
    private bool hasFallen = false;
    
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        
        
    }

    private void Update()
    {
        
        if (talkDelay.currentText == "（話に耳を傾けた。）"|| talkDelay.currentText == "部活を辞めようか迷っていて" & !hasFallen)
        {
            Debug.Log("物が落ち始めました");
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
            
            /*for (int i = 0; i < caunt; i++)
            {
                targetObject[i].SetActive(true);
            }*/
        }
    }
}