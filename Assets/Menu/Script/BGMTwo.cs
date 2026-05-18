using UnityEngine;

public class BGMTwo : MonoBehaviour
{
    public static BGMTwo bgmTwo;
    
    void Awake()
    {
        transform.SetParent(null);
        if (bgmTwo == null)
        {
            bgmTwo = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
