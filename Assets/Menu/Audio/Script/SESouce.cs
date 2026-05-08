using UnityEngine;

public class SESouce : MonoBehaviour
{
    public static SESouce audioSInstance
    {
        get; private set;
    }
    void Awake()
    {
        if (audioSInstance == null)
        {
            audioSInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
