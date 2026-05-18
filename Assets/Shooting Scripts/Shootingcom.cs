using UnityEngine;
using System.Collections;

public class Shootingcom : MonoBehaviour
{
    //public GameObject textPrefab;
    //public RectTransform spawnArea;

    public float spawnInterval = 1.0f;

    private bool isPlaying = false;

    public int finisheCout = 0;
    public int maxSpawn = 25;

    public Shootingend ending;

    public void StartGame()
    {

        isPlaying = true;
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (isPlaying)
        {
            

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void ONtextfinished()
    {
        finisheCout++;
        if (finisheCout > maxSpawn)
        {
            isPlaying = false;

            if (ending != null)
            {
                ending.Startfade();
            }
        }
    }

}