using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;

public class Testshooting : MonoBehaviour
{
    public Shootingstart fall;
    GameManager gameManager;
    public Shootingcom com;
    [SerializeField]
    Preya_min Player_;
    public GameObject player;
    public GameObject[] Enemy;

    public bool isHit = false;

   public IEnumerator S_Start(int i)
    {
        Debug.Log("S_Start‚ª“Ç‚Ýž‚Ü‚ê‚Ü‚µ‚½");
        //yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(0.1f);
        player.SetActive(true);
        Enemy[i].SetActive(true);
        Player_.SetBattlephase(i);   
        //com.StartGame();
        yield return new WaitUntil(() => isHit);
        isHit = false;

    }

    public void HitReaction(bool i)
    {
        if(i)
        {
            isHit = true;
        }
    }
}
