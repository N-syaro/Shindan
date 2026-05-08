using UnityEngine;

public class BGMOne : MonoBehaviour
{
    public static BGMOne audioSInstance
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
