using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackLogDisplay : MonoBehaviour
{
    [SerializeField] private GameObject viewportContentsPrefab;
    [SerializeField] private TalkController talkController; // ★InspectorでアサインするかFind

    private RectTransform contentRectTransform;
    private RectTransform scrollViewRectTransform;

    void Start()
    {
       // TalkControllerからリストを取得 後で変更
       List<(string Name, string Text)> backlogLogTextList = talkController.GetBacklogList();

        Transform backlog = transform;
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
        scrollRect.verticalNormalizedPosition = 0;
    }

    private void InstanceViewportContents(string nameText, string sentenceText, Transform content)
    {
        GameObject newViewportContents = Instantiate(viewportContentsPrefab, content);
        Text nameText_ = newViewportContents.transform.GetChild(0).GetComponent<Text>();
        Text sentenceText_ = newViewportContents.transform.GetChild(1).GetComponent<Text>();
        nameText_.text = nameText;
        sentenceText_.text = sentenceText;
    }

    void BacklogClose()
    {
        Destroy(this.gameObject);
    }
}