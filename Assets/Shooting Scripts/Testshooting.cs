using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;

public class Testshooting : MonoBehaviour
{
    public Shootingstart fall;
    
    public Shootingcom com;

   public IEnumerator S_Start()
    {
        Debug.Log("S_StartÇ™ì«Ç›çûÇ‹ÇÍÇ‹ÇµÇΩ");
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(fall.fallDuration);

        com.StartGame();


    }
}
