using UnityEngine;
using UnityEngine.SceneManagement;

public class gemu_obuge : MonoBehaviour
{
    //敵の生成処理のスクリプト
    [SerializeField]
    GameManager gameManager;
    public bool stat=true;
    public GameObject[] enemiobuject;//生成するゲームオブジェクト
    public float[] spulnt;//生成するタイミング
    private string SceneName;
    float taimudl;//経過時間
    int next = 0;//生成する数
    bool onstop;

    /*
     * 生成しきったらgamemangerのExp_endをtrueにする処理を入れたい
     * 
     *
     */
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;

    }

    

    // Update is called once per frame
    void Update()
    {
        if (enemiobuject==null)return;
            taimudl += Time.deltaTime;
        //タイマー
        if (next < taimudl && next < spulnt.Length)//順次生成処理
        {

            if (taimudl > spulnt[next])
            {
                sponw();
                next++;
            }
        }
    }
    void sponw()//生成処理
    {

        Instantiate(enemiobuject[next]);
        Debug.Log("spon");
    }
}

