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

    public string currentText;

    public void SKip()//スキップフラグ
    {
        isSkip = true;
    }
    public void TurnBacklogMode()
    {
        if (!isMode)
        { 
            
            isMode = true;
            Debug.Log(isMode);
        }
        else 
        {
            isMode = false;
            Debug.Log(isMode);
        }
       
    }
    public  IEnumerator TextActive(Text text,string Data)//一文字ずつ流すコード
    {
        yield return new WaitUntil(()=>!isMode);
        if(Data == null) { yield break;}
        currentText = Data;
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
        isSkip = false;
        yield return new WaitUntil(() => isSkip);
       // yield return new WaitForSeconds(1f);
      
    }
}
