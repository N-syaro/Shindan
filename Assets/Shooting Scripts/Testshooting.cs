using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;

public class Testshooting : MonoBehaviour
{
    public Shootingstart fall;
    public Shootingend fade;
    public Shootingcom com;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);


        yield return new WaitForSeconds(fall.fallDuration);

        com.StartGame();


    }
}
