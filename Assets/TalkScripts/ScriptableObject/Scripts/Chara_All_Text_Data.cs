using UnityEngine;

//データまとめ
[CreateAssetMenu(fileName = "AllText_Data", menuName = "Game/Text/Saved/AllText_Data")]
public class Chara_All_Text_Data : ScriptableObject
{
    [SerializeField, Header("データのキャラクターネーム(確認用)")] private string Name;
    [SerializeField, Header("キャラクターテキストデータまとめ")] public Setting_Text_Data[] AllTextData;
}
