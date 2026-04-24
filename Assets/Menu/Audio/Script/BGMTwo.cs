using UnityEngine;

public class BGMTwo : MonoBehaviour
{
    private BGMTwo bgmTwo;
    
    void Awake()
    {
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
