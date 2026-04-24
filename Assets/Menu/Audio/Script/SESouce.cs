using UnityEngine;

public class SESouce : MonoBehaviour
{
    private SESouce seSouce;
    
    void Awake()
    {
        if (seSouce == null)
        {
            seSouce = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
