using UnityEngine;
using System.Collections;

public class TestShoooting : MonoBehaviour
{
    public UIFall fall;
    public ScreenFade fade;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        fall.StartFall();

        yield return new WaitForSeconds(fall.fallDuration);

        fade.StartFade();
    }
}