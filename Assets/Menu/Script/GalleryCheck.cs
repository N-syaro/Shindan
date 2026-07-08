using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GalleryCheck : MonoBehaviour
{

    string Title = "Title";

    public FadeOutIn fadeout;

    IEnumerator Start()
    {
        
        //1フレーム待つ(消えてしまうオブジェクトを参照しないようにするため) 
        yield return null;


        fadeout = FindFirstObjectByType<FadeOutIn>();

    }

    public void OKButton()
    {
        this.gameObject.SetActive(false);
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
