using UnityEngine;
using UnityEngine.UI;

public class ballt : MonoBehaviour
{
    [SerializeField] public Image image;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "neo")
        {
            
            Destroy(collision.gameObject);
            //image.enabled = true;
        }

        Destroy(gameObject);
    }
}
