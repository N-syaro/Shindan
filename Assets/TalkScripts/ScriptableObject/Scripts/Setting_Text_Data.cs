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
    [SerializeField,Header("弾幕突入")]public bool IsTalkEnd;
    [SerializeField, Header("ボイスデータ番号")] public int VoiceDeta_;
    [SerializeField, Header("ボイスデータ番号2")] public int VoiceDeta_Two;
    [SerializeField, Header("BGMデータ番号")] public int BGMDeta_;
    [SerializeField, Header("BGMデータ番号2")] public int BGMDeta_Two;
    [SerializeField, Header("SEデータ番号")] public int SEDeta_;
    [SerializeField, Header("BGM変更データ番号")] public int BGMDeta_Change;
}
