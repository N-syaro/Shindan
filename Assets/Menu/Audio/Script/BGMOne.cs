using UnityEngine;

public class BGMOne : MonoBehaviour
{
    private BGMOne bgmOne;
    
    void Awake()
    {
        if (bgmOne == null)
        {
            bgmOne = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
