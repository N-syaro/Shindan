using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelActive : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField,Header("ëJà⁄ÉVÅ[ÉìÇÃñºëO")]
    private string SceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
        StartCoroutine(Panelactive());
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
        SceneManager.LoadScene(SceneName);
    }
}