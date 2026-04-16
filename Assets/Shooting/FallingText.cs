using UnityEngine;

public class FallingText : MonoBehaviour
{
    public float speed = 300f;

    private RectTransform rectTransform;

    public Shoootingcom manager;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += Vector2.down * speed * Time.deltaTime;

        
        if (rectTransform.anchoredPosition.y < -Screen.height)
        {
            if (manager  != null)
            {
                manager.ONtextfinished();
            }


            Destroy(gameObject);
        }
    }
}
