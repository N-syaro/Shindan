using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{

    [SerializeField] GameObject showCanvas;

    [SerializeField] GameObject checkCanvas;

    [SerializeField] Image showImage;


    string Title = "Title";

    public FadeOutIn fadeout;

    IEnumerator Start()
    {
        showCanvas.SetActive(false);
        checkCanvas.gameObject.SetActive(true);

        //1フレーム待つ(消えてしまうオブジェクトを参照しないようにするため) 
        yield return null;


        fadeout = FindFirstObjectByType<FadeOutIn>();

    }
    


    public void ShowButton(Sprite sprite)
    {
        showCanvas.SetActive(true);

        showImage.sprite = sprite;
        
    }

    public void ReturnButton()
    {
        showCanvas.SetActive(false);

    }

    public void OKButton()
    {
        checkCanvas.gameObject.SetActive(false);
    }

    public void NOButton()
    {


        if (fadeout != null)
        {
            fadeout.fadeOutIn(0f, 0.2f, 0.2f);
        }
        else
        {
            Debug.LogError("フェードオブジェクトがない");
        }

        //タイトル画面に戻る
        SceneManager.LoadScene(Title);

    }


}
