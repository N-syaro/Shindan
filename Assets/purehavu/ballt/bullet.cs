using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision2d)
    {
        if(collision2d.gameObject.CompareTag("EnemyBullet"))
        {

        }
    }
}
