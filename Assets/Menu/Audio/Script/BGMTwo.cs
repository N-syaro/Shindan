using UnityEngine;

public class BGMTwo : MonoBehaviour
{
    public static BGMTwo audioSInstance
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
