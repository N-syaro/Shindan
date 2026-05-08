using UnityEngine;

public class BGMOne : MonoBehaviour
{
    public static BGMOne bgmOne;
    
    void Awake()
    {
        transform.SetParent(null);
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
