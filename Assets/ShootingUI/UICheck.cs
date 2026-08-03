using UnityEngine;

public class UICheck : MonoBehaviour
{


    [SerializeField]
    GameObject shootingUI;
    
    private bool targetActiveState;
    private AmmoUI ammoUI;

    [SerializeField]
    GameObject preya_min;

    [SerializeField]
    GameObject priyaBOX;
    
    private bool playerActiveState;

    SpriteRenderer playerSprite;

    Enm enm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (shootingUI != null)
        {
            // 初期状態を保持
            targetActiveState = shootingUI.activeSelf;

            ammoUI = shootingUI.GetComponent<AmmoUI>();
        }
        if (priyaBOX != null)
        {
            playerSprite=priyaBOX.GetComponent<SpriteRenderer>();

            enm=priyaBOX.GetComponent<Enm>();

        }
        if(preya_min != null)
        {
            // 初期状態を保持
            playerActiveState = preya_min.activeSelf;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingUI != null)
        {
            bool currentActiveState = shootingUI.activeSelf;
            if (!targetActiveState && currentActiveState)
            {
                Debug.Log("shootingUIが非アクティブからアクティブになりました！");


                StartCoroutine(ammoUI.AmmoInitialization());
            }
            targetActiveState = currentActiveState;
        }
        if (preya_min != null)
        {
            bool currentActiveState = preya_min.activeSelf;
            if (!playerActiveState && currentActiveState)
            {
                Debug.Log("preya_minが非アクティブからアクティブになりました！");

                PlayerSpriteInitialization();
            }
            playerActiveState = currentActiveState;
        }

        void PlayerSpriteInitialization()
        {
            playerSprite.enabled = true;
            enm.isHit = false;
            enm.hit = false;
        }
    }
}
