using System.Collections.Generic;
using UnityEngine;

public class MainTextController : MonoBehaviour
{
    //略
    private List<(int LineNumber, string Name, string Text)> logTextList = new List<(int, string, string)>();

    //中略

    // テキストを表示
    public void DisplayText(string sentence, bool isStatement)
    {

        string[] words = sentence.Split(',');

        string namesentence = words[2];
       // string textsentence = GameManager.Instance.variablesManager.ReplaceVariablesInExpression(words[3]);
        if (isStatement)
        {
          //  _mainTextObject.text = null;
          //  _nameTextObject.text = null;

        }
        else
        {
           // _mainTextObject.text = textsentence;
           // _nameTextObject.text = namesentence;
            // 行番号とともにリストに追加
           // int lineNumber = GameManager.Instance.lineNumber;
           // logTextList.Add((lineNumber, namesentence, textsentence));
        }

    }

    // ログテキストリストを取得するためのgetterメソッド
    public List<(int LineNumber, string Name, string Text)> GetLogTextList()
    {
        return new List<(int LineNumber, string Name, string Text)>(logTextList);
    }
}
