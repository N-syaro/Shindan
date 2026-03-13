using UnityEngine;


//キャラクターデータ保存用
[CreateAssetMenu(fileName ="Chara_Data",menuName ="Game/Chara_Data")]
public class Chara_data : ScriptableObject
{
    [Header("キャラ名")] public string Name;
    [Header("キャラ画像")] public Sprite[] Image;
}
