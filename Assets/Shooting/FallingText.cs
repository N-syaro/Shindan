using UnityEngine;

public class FallingText : MonoBehaviour
{
    public float speed = 300f;

    void Update()
    {
     transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        if (transform.position.y < Screen.height)
        {
            Destroy(gameObject);
        }
    }
}
