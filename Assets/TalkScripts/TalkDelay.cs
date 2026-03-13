using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class TalkDelay : MonoBehaviour
{
    private bool isSkip = false;

    public void SKip()//スキップフラグ
    {
        isSkip = true;
    }
    public  IEnumerator TextActive(Text text,string Data)//一文字ずつ流すコード
    {
        if(Data == null) { yield break;}
        isSkip = false;
        text.text = "";

        for(var i = 0;i<Data.Length;i++)
        {
            if (isSkip)
            {
                text.text = Data;
                break;
            }
            yield return new WaitForSeconds(0.1f);
            text.text += Data[i];
        }
        yield return new WaitForSeconds(1f);
    }
}
