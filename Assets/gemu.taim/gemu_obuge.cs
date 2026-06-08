using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gemu_obuge : MonoBehaviour
{
    //“G‚Ì¶¬ˆ—‚ÌƒXƒNƒŠƒvƒg
    [SerializeField]
    GameManager gameManager;
    public bool stat=true;
    public GameObject[] enemiobuject;//¶¬‚·‚éƒQ[ƒ€ƒIƒuƒWƒFƒNƒg
    public float[] spulnt;//¶¬‚·‚éƒ^ƒCƒ~ƒ“ƒO
    private string SceneName;
    float taimudl;//Œo‰ßŽžŠÔ
    int next = 0;//¶¬‚·‚é”
    bool onstop;
<<<<<<< HEAD
    GameObject gamemanager;
    GameManager dawe;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        /*gamemanager = GameObject.Find("GameManagar");
        dawe = gamemanager.GetComponent<GameManager>();
        */
=======

    /*
     * ¶¬‚µ‚«‚Á‚½‚çgamemanger‚ÌExp_end‚ðtrue‚É‚·‚éˆ—‚ð“ü‚ê‚½‚¢
     * 
     *
     */
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
>>>>>>> origin/è«¸ã€…ä½œæˆ

    }

    

    // Update is called once per frame
    void Update()
    {
        if (enemiobuject==null)return;
            taimudl += Time.deltaTime;
        //ƒ^ƒCƒ}[
        if (next < taimudl && next < spulnt.Length)//‡ŽŸ¶¬ˆ—
        {

            if (taimudl > spulnt[next])
            {
                sponw();
                next++;
            }
<<<<<<< HEAD
           /* else if (next >= spulnt.Length) 
            {
                dawe.endCount=true;
                Debug.Log(dawe.endCount);
            }
           */
           
=======
>>>>>>> origin/è«¸ã€…ä½œæˆ
        }
    }
    void sponw()//¶¬ˆ—
    {

        Instantiate(enemiobuject[next]);
        Debug.Log("spon");
    }
}

