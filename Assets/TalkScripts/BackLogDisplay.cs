using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackLogDisplay : MonoBehaviour
{
    // バックログに表示するテキストのリスト
    private List<(int LineNumber, string Name, string Text)> backlogLogTextList;

    // ViewportContentsのプレハブ
    [SerializeField] private GameObject viewportContentsPrefab;


    // ContentのRectTransform
    private RectTransform contentRectTransform;

    // ScrollViewのRectTransform
    private RectTransform scrollViewRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        // バックログのテキストリストを取得
       // backlogLogTextList = GameManager.Instance.mainTextController.GetLogTextList();

        // バックログを見つける
        Transform backlog = transform;

        // ViewportとContentとbuttonを探す
        Transform viewport = null;
        Transform content = null;
        GameObject BacklogCloseObject = null;
        foreach (Transform child in backlog)
        {
            if (child.name == "BacklogClose")
            {
                BacklogCloseObject = child.gameObject;
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

        //閉じるボタンを取得
        Button BacklogCloseComponent = BacklogCloseObject.GetComponent<Button>();
        BacklogCloseComponent.onClick.AddListener(BacklogClose);



        // ViewportContentsのプレハブをContentの下にインスタンス化し、Contentの高さを要素数に応じて調整
        if (viewport != null && content != null)
        {
            // ContentのRectTransformを取得
            contentRectTransform = content.GetComponent<RectTransform>();

            // ScrollViewのRectTransformを取得
            scrollViewRectTransform = viewport.parent.GetComponent<RectTransform>();

            // ViewportContentsのプレハブをContentの下にインスタンス化
            string NameText = "";
            string SentenceText = "";
            for (int i = 0; i < backlogLogTextList.Count; i++)
            {
                NameText = backlogLogTextList[i].Name;
                SentenceText = backlogLogTextList[i].Text;
                InstanceViewportContents(NameText, SentenceText, content);
            }

        }
        ScrollRect scrollRect = GetComponent<ScrollRect>();
        scrollRect.verticalNormalizedPosition = 0;
    }

    // ViewportContentsをインスタンス化する
    private void InstanceViewportContents(string nameText, string SentenceText, Transform content)
    {
        GameObject newViewportContents = Instantiate(viewportContentsPrefab, content);

        GameObject ViewportName = newViewportContents.transform.GetChild(0).gameObject;
        GameObject ViewportSentence = newViewportContents.transform.GetChild(1).gameObject;
        TextMeshProUGUI nameTextMeshPro = ViewportName.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI sentenceTextMeshPro = ViewportSentence.GetComponent<TextMeshProUGUI>();
        nameTextMeshPro.text = nameText;
        sentenceTextMeshPro.text = SentenceText;
    }

    void BacklogClose()
    {
        //GameManager.Instance.displayMenu.TurnOffLog();
        Destroy(this.gameObject); // バックログの親オブジェクトを破棄
    }

}

