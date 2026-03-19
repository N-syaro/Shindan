using UnityEngine;
using System.Collections;
using Unity.VisualScripting;



public class Shootingstart : MonoBehaviour
{
    private RectTransform rectTransform;
    public float duration = 2.0f;


    private bool isMoving = false;

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
            StartCoroutine(Shootingdown());
        }
    }

    IEnumerator Shootingdown()
    {
        yield return new WaitForSeconds(2.0f);

        Vector2 startPos = new Vector2(rectTransform.anchoredPosition.x, 1000);
        Vector2 endPos = new Vector2(rectTransform.anchoredPosition.x, 0f);

        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, t);

            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
        isMoving = false;
    }
}
