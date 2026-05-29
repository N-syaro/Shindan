using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [Header("ƒV[ƒ“‚Ì–¼‘O"),SerializeField]
    public string SceneName;
   public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
