using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class TalkDelay : MonoBehaviour
{
    private bool isMode = false;
    private bool isSkip = false;

    public void SKip()//スキップフラグ
    {
        isSkip = true;
    }
    public void TurnBacklogMode()
    {
        if (!isMode)
        { 
            isMode = true;
        }
        else 
        {
            isMode = false;
        }
       
    }
    public  IEnumerator TextActive(Text text,string Data)//一文字ずつ流すコード
    {
        yield return new WaitUntil(()=>!isMode);
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
