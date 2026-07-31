using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField]
    GameObject[] ammos;
    
    [SerializeField]
    Preya_min preya_Min;

    [SerializeField]
    Slider ammoSlider;

    private int uiBalet = 0;
    /*
    float correctionTimer = 3f;
    bool correction = false;
    float timer = 0f;
    */
    public GameObject CurrentSelectedAmmo
    {
        get
        {
            if (IsActiveAmmo(uiBalet))
            {
                return ammos[uiBalet];
            }
            return null; // アクティブな弾がない場合
        }
    }

    public int CurrentAmmoIndex => uiBalet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ammos.Length > 0 && !IsActiveAmmo(uiBalet))
        {
            FindNextActive(1); // 前方に探す
        }
        UpdateScale();
    }

    // Update is called once per frame
    void Update()
    {
        float wh = Input.mouseScrollDelta.y;
        if (wh != 0)
        {
            int direction = wh > 0 ? 1 : -1;

            // 非アクティブなものをスキップして次の要素を探す
            FindNextActive(direction);

            UpdateScale();
        }
        /*
        timer += Time.deltaTime;
        if (timer > correctionTimer&&correction)
        {
            StartCoroutine(AmmoCorrection());
        }
        */




    }

    void FindNextActive(int direction)
    {
        int maxLenght = ammos.Length; // 基準をammosの数に合わせます
        if (maxLenght == 0) return;

        int originalBalet = uiBalet;
        bool foundActive = false;

        while (!foundActive)
        {
            // インデックスの増減
            uiBalet += direction;

            // 境界チェック（ループ処理）
            if (uiBalet >= maxLenght)
            {
                uiBalet = 0;
            }
            else if (uiBalet < 0)
            {
                uiBalet = maxLenght - 1;
            }

            // 指定したインデックスのAmmoがアクティブかチェック
            if (IsActiveAmmo(uiBalet))
            {
                foundActive = true;
            }

            // 1周してもアクティブなものがなければ無限ループを防ぐために抜ける
            if (uiBalet == originalBalet)
            {
                break;
            }
        }
    }

    bool IsActiveAmmo(int index)
    {
        if (index < 0 || index >= ammos.Length) return false;

        GameObject ammo = ammos[index];
        // GameObjectが存在し、かつヒエラルキー上でアクティブ（表示状態）であるか
        return ammo != null && ammo.activeInHierarchy;
    }


    void UpdateScale()
    {
        for (int i = 0; i < ammos.Length; i++)
        {
            if (ammos[i] == null) continue;
            // 非アクティブなものは拡大縮小の更新をスキップ
            if (!ammos[i].activeInHierarchy)
            {
                continue;
            }

            Image ammoImage = ammos[i].GetComponent<Image>();

            if (i == uiBalet)
            {
                //選ばれてる弾
                ammos[i].transform.localScale = new Vector3(1.2f, 1.3f, 1f);

                if (ammoImage != null)
                {
                    ammoImage.color = Color.white;
                }
                    
            }
            else
            {
                //選ばれてない弾
                ammos[i].transform.localScale = new Vector3(1f, 1f, 1f);

                if (ammoImage != null)
                {
                    ammoImage.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                }
            }
        }
    }

    public IEnumerator AmmoCool()
    {
        //correction = false;
        float time = 0f;

        ammoSlider.value = 0f;

        while (time<preya_Min.dlitm)
        {
            time += Time.deltaTime;
            ammoSlider.value = Mathf.Lerp(0, 1, time / preya_Min.dlitm);
            
            yield return null;
        }
        
        ammoSlider.value = 1f;
        //correction = true;
        //timer = 0f;
    }
    /*
    public IEnumerator AmmoCorrection()
    {
        correction = false;
        yield return new WaitForSeconds(2.0f);
        ammoSlider.value = 1f;
        correction = true;
        timer = 0f;
    }
    */
}
