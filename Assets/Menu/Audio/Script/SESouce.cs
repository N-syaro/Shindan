using UnityEngine;

public class SESouce : MonoBehaviour
{
    public static SESouce seSouce;
    
    void Awake()
    {
        transform.SetParent(null);
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
