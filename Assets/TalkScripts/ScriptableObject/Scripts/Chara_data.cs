using UnityEngine;
using System.Collections.Generic;

// 対応言語の定義
public enum Language { Japanese, English }

[System.Serializable]
public class LocalizedName
{
    public Language language;
    public string name;
}

//キャラクターデータ保存用
[CreateAssetMenu(fileName = "Chara_Data", menuName = "Game/Chara_Data")]
public class Chara_data : ScriptableObject
{
    [Header("キャラ名")] public List<LocalizedName> Names = new List<LocalizedName>();
    [Header("キャラ画像")] public Sprite[] Image;

    // 現在の言語に対応する名前を取得
    public string GetName(Language lang)
    {
        var entry = Names.Find(n => n.language == lang);
        if (entry != null) return entry.name;
        return Names.Count > 0 ? Names[0].name : "";
    }
}
