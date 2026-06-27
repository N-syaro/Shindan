using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Col : MonoBehaviour
{

    public GameManager manager;

    string ActiveSceneName;
    private void Start()
    {
        ActiveSceneName = SceneManager.GetActiveScene().name;
        GameObject G_manager = GameObject.Find("GameManager");
        manager = G_manager.GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (ActiveSceneName)
        {
            case "JP Main":
                switch (collision.gameObject.tag)
                {
                    case "Ballet1":
                        manager.HitBalletNumber(1);
                        break;
                    case "Ballet2":
                        manager.HitBalletNumber(2);
                        break;
                    case "Ballet3":
                        manager.HitBalletNumber(3);
                        break;
                    case "Ballet4":
                        manager.HitBalletNumber(4);
                        break;
                }
                break;  
        }       
    }
}
