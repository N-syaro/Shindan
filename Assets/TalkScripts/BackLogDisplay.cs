using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackLogDisplay : MonoBehaviour
{
    [SerializeField] private GameObject viewportContentsPrefab;
    [SerializeField] private TalkController talkController; 

    private RectTransform contentRectTransform;
    private RectTransform scrollViewRectTransform;
    private GameObject GameManager;
    private DisplayMenu D_Menu;
    [System.Obsolete]
    void Start()
    {
        if (D_Menu == null)
        {
            D_Menu = FindObjectOfType<DisplayMenu>();
            if (D_Menu == null)
            {
                Debug.LogError("D_Menuがシーン内に見つかりません");
                return;
            }
            Debug.Log("D_Menuを自動取得しました: " + D_Menu.name);
        }
        if (talkController == null)
        {
            talkController = FindObjectOfType<TalkController>();
            if (talkController == null)
            {
                Debug.LogError("TalkControllerがシーン内に見つかりません");
                return;
            }
            Debug.Log("TalkControllerを自動取得しました: " + talkController.name);
        }
        // TalkControllerからリストを取得 後で変更
        List<(string Name, Sprite p_image, string Text)> backlogLogTextList = talkController.GetBacklogList();
        Debug.Log("バックログ件数: " + backlogLogTextList.Count);
        Transform backlog = transform;
        Transform viewport = null;
        Transform content = null;
        GameObject BacklogCloseObject = null;

        foreach (Transform child in backlog)
        {
            Debug.Log("a");
            if (child.name == "BacklogClose")
            {
                BacklogCloseObject = child.gameObject;
                if(BacklogCloseObject == null)
                {
                    Debug.LogError("BacklogCloseObject is null");
                    return;
                }
                
            }
            if (child.name == "Viewport")
            {
                viewport = child;
                foreach (Transform grandchild in child)
                {
                    if (grandchild.name == "Content")
                    {
                        content = grandchild;
                        break;
                    }
                }
            }
         
        }

       Button BacklogCloseComponent = BacklogCloseObject.GetComponent<Button>();
       BacklogCloseComponent.onClick.AddListener(BacklogClose);

        if (viewport != null && content != null)
        {
            contentRectTransform = content.GetComponent<RectTransform>();
            scrollViewRectTransform = viewport.parent.GetComponent<RectTransform>();

            foreach (var entry in backlogLogTextList)
            {
                InstanceViewportContents(entry.Name, entry.Text, content);
            }
        }

        ScrollRect scrollRect = GetComponent<ScrollRect>();
        if (scrollRect == null)
        {
            Debug.LogError("ScrollRectが自身に見つかりません");
            
        }
        scrollRect.verticalNormalizedPosition = 0;

        StartCoroutine(ScrollToBottom(scrollRect));
    }
    private void InstanceViewportContents(string nameText, string sentenceText, Transform content)
    {
        GameObject newViewportContents = Instantiate(viewportContentsPrefab, content);
        Text nameText_ = newViewportContents.transform.GetChild(0).GetComponent<Text>();
        Text sentenceText_ = newViewportContents.transform.GetChild(1).GetComponent<Text>();
        nameText_.text = nameText;
        sentenceText_.text = sentenceText;
    }

    private IEnumerator ScrollToBottom(ScrollRect scrollRect)
    {
        // 1フレーム待ってレイアウト計算を完了させる
        yield return null;

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRectTransform);

        // もう1フレーム待つ（念のため）
        yield return null;

        scrollRect.verticalNormalizedPosition = 0f;
    }
    void BacklogClose()
    {
        D_Menu.TurnOffLog();
        Destroy(this.gameObject);
    }
}