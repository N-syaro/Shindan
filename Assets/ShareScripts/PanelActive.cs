using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelActive : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField,Header("ëJà⁄ÉVÅ[ÉìÇÃñºëO")]
    private string SceneName;

    [SerializeField] MenuManager menuManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start() 
    {
        panel.SetActive(false);
        StartCoroutine(Panelactive());

        yield return null;

        menuManager = FindFirstObjectByType<MenuManager>();
    }
    private void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            panel.SetActive(true);
        }
    }
    private IEnumerator Panelactive()
    {
        yield return new WaitForSeconds(5f);

        panel.SetActive(true);
        
    }

    public void SceneLoad()
    {
        menuManager.bgmSwap(3);

        SceneManager.LoadScene(SceneName);
    }
}