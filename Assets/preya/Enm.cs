using UnityEngine;

public class Enm : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnHit");
        if (collision.gameObject.tag == "Enemy") 
        {
            Debug.Log("dameg");
        
        }
    }
}
