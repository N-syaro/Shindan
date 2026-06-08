using System.Collections;
using System.Resources;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkDelay : MonoBehaviour
{
    private bool isMode = false;
    private bool isSkip = false;

    public string currentText;

    //----石上変更点----

    public AudioSourceManager sourceManager;

    IEnumerator Start()
    {
        // 1フレーム待つ(消えてしまうオブジェクトを参照しないため)
        yield return null;

        
        sourceManager = FindFirstObjectByType<AudioSourceManager>();

        if (sourceManager == null)
        {
            Debug.LogWarning("AudioSourceManager が見つかりませんでした。");
        }
        else
        {
            Debug.Log("AudioSourceManager が見つかりました");
        }
    }


    //------------------


    public void SKip()//スキップフラグ
    {
        isSkip = true;

        //------------------
        sourceManager.seChange(3);
        //------------------

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
        yield return new WaitForSeconds(1f);
      
    }
}
