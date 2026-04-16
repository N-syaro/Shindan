using UnityEngine;
using System.Collections;

public class TestShoooting : MonoBehaviour
{
    public UIFall fall;
    public Shootingend fade;
    public Shoootingcom com;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        fall.StartFall();

        yield return new WaitForSeconds(fall.fallDuration);

        com.StartGame();

      
    }
}