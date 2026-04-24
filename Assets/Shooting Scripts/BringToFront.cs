using UnityEngine;

public class BringToFront : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        // ソートレイヤー（任意）
        sr.sortingLayerName = "Foreground";

        // 描画順（大きいほど前）
        sr.sortingOrder = 10;
    }
}