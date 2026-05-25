using UnityEngine;
using UnityEngine.UI;

public class ballt : MonoBehaviour
{
    [SerializeField] public Image image;
    public GameObject obze;//シューティングゲームのオブジェクト

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "neo")//シューティングゲームの終了
        {

            Destroy(collision.gameObject);
           

        }

        Destroy(gameObject);
    }
}
