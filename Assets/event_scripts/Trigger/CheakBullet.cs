using UnityEngine;
using UnityEngine.SceneManagement;

public class CheakBullet : MonoBehaviour
{
    private const string LAYER_NAME_coreect = "coreect";
    private const string LAYER_NAME_incoreect = "incoreect";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layerA = LayerMask.NameToLayer(LAYER_NAME_coreect);
        int layerB = LayerMask.NameToLayer(LAYER_NAME_incoreect);

        if (collision.gameObject.layer == layerA)
        {
            SceneManager.LoadScene("END Credits");
        }
        if (collision.gameObject.layer == layerB)
        {
            SceneManager.LoadScene("Bad END");
        }


    }


}
