using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gemu_obuge : MonoBehaviour
{
    //敵の生成処理のスクリプト
    [SerializeField]
    GameManager gameManager;
    public bool stat = true;
    public GameObject[] enemiobuject;//生成するゲームオブジェクト
    public float[] spulnt;//生成するタイミング
    private string SceneName;
    float taimudl;//経過時間
    int next = 0;//生成する数
    bool onstop;
    bool searchstop = false;

    GameObject gamemanager;
    GameManager dawe;
    Testshooting tes_s;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        gamemanager = GameObject.Find("GameManager");
        dawe = gamemanager.GetComponent<GameManager>();
        tes_s = gamemanager.GetComponent<Testshooting>();
        SceneName = SceneManager.GetActiveScene().name;


        /*
         * 生成しきったらgamemangerのExp_endをtrueにする処理を入れたい
         * 
         *
         */
        // Start is called once before the first execution of Update after the MonoBehaviour is created


    }

    // Update is called once per frame
    void Update()
    {
        //if (enemiobuject==null)return;
        taimudl += Time.deltaTime;
        //タイマー
        if (next < taimudl && next < spulnt.Length)//順次生成処理
        {

            if (taimudl > spulnt[next])
            {
                sponw();
                next++;
            }
            if (enemiobuject.Length <= next)
            {
                StartCoroutine(endcreate());
                Debug.Log("a");
                return;
            }
        }
    }
    void sponw()//生成処理
    {

        Instantiate(enemiobuject[next]);
        Debug.Log("spon");
    }

    void za()
    {
        dawe.EndShooting(true);
        tes_s.HitReaction(true);
        searchstop = false;
    }
    IEnumerator endcreate()
    {
        Debug.Log("endcreateが読み込まれました");
        switch (SceneName)
        {
            case "JP":
                yield return new WaitForSeconds(5f);
                za();
                searchstop = true;
            break;

            case "JP Main":
                yield return new WaitForSeconds(6f);

            break;
        }


        yield break;
    }
}