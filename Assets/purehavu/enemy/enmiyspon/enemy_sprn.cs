using UnityEngine;

public class enemy_sprn : MonoBehaviour
{
    public Vector2 waldpos;
    public float mube=5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pose=transform.position;
        transform.position= Vector2.MoveTowards(pose, waldpos, mube);
        
    }
}
