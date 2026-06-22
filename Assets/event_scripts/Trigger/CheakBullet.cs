using UnityEngine;
using UnityEngine.SceneManagement;

public class CheakBUllet : MonoBehaviour
{
    [SerializeField] private TalkController talkController;

    [SerializeField] private MakeConversation okData;
    [SerializeField] private MakeConversation noData;

    private const string LAYER_NAME_coreect = "coreect";
    private const string LAYER_NAME_incoreect = "incoreect";

    [SerializeField] private Enm enm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layerA = LayerMask.NameToLayer(LAYER_NAME_coreect);
        int layerB = LayerMask.NameToLayer(LAYER_NAME_incoreect);

        if (collision.gameObject.layer == layerA)
        {
            talkController.CTalk(okData);
        }
        if (collision.gameObject.layer == layerB)
        {
            //enm.taima += 15f; //‰¼‚È‚Ì‚ÅŒˆ‚Ü‚ê‚Î•Ï‚¦‚é
            talkController.CTalk(noData);
        }


    }

}
