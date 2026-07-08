using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField]
    GameObject[] ammos;
    
    [SerializeField]
    Preya_min preya_Min;

    private int uiBalet = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScale();
    }

    // Update is called once per frame
    void Update()
    {
        float wh = Input.mouseScrollDelta.y;
        if (wh != 0)
        {
            if (wh > 0)
            {
                uiBalet++;
            }
            if (wh < 0) 
            {
                uiBalet--;
            }
            
            int maxLenght = preya_Min.bart.Length;

            if (uiBalet >= maxLenght) 
            {
                uiBalet = 0;
            }
            else if (uiBalet < 0) 
            {
                uiBalet = maxLenght - 1;
            }
            UpdateScale();
        }



        

    }


    void UpdateScale()
    {
        for (int i = 0; i < ammos.Length; i++)
        {
            if (ammos[i] == null) continue;

            Image ammoImage = ammos[i].GetComponent<Image>();

            if (i == uiBalet)
            {
                //‘I‚Î‚ê‚Ä‚é’e
                ammos[i].transform.localScale = new Vector3(1.2f, 1.3f, 1f);

                if (ammoImage != null)
                {
                    ammoImage.color = Color.white;
                }
                    
            }
            else
            {
                //‘I‚Î‚ê‚Ä‚È‚¢’e
                ammos[i].transform.localScale = new Vector3(1f, 1f, 1f);

                if (ammoImage != null)
                {
                    ammoImage.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                }
            }
        }
    }
}
