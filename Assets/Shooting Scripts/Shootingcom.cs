using UnityEngine;
using System.Collections;

public class Shootingcom : MonoBehaviour
{
    public GameObject textPrefab;
    public RectTransform spawnArea;

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
            SpawnText();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnText()
    {
        GameObject obj = Instantiate(textPrefab, spawnArea);
        obj.transform.SetAsLastSibling();

        RectTransform rt = obj.GetComponent<RectTransform>();

        float x = Random.Range(
            spawnArea.rect.xMin,
            spawnArea.rect.xMax
        );

        float y = spawnArea.rect.yMax;

        rt.anchoredPosition = new Vector2(x, y);
        FallingText fall = obj.GetComponent<FallingText>();
        if (fall != null)
        {
            fall.manager = this;
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