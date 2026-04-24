using System.Diagnostics;
using UnityEngine;


//1セリフ保存用
[CreateAssetMenu(fileName = "Setting_Text_Data", menuName = "Game/Text/Setting/Normal")]
public class Setting_Text_Data : ScriptableObject
{
    [SerializeField, Header("テキストデータ")] public string TextData;
    [SerializeField, Header("サイド(主人公がしゃべるときtrue(仮))")] public bool Side;
    [SerializeField, Header("セリフ主のデータ")] public Chara_data Talking_chara;
    public Switch s;
    public int CHImageNum_ = 0;
    [SerializeField, Header("シーンの名前")] public string SceneName = null;
}
