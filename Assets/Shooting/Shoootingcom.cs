using UnityEngine;
using System.Collections;

public class Shoootingcom : MonoBehaviour
{
    public GameObject textPrefab;
    public RectTransform spawnArea;

    public float spawnInterval = 1.0f;

    private bool isPlaying = false;

    public void StartGame() 
    {
        isPlaying = true;
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (isPlaying)
        {
            SpawnText();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnText()
    {
        float x = Random.Range(
             spawnArea.rect.xMin,
             spawnArea.rect.xMax
         );

        Vector3 spawnPos = new Vector3(
            spawnArea.position.x + x,
            spawnArea.position.y,
            0
        );

        Instantiate(textPrefab, spawnPos, Quaternion.identity, spawnArea);
    }
}
