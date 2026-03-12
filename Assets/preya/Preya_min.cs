using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Preya_min : MonoBehaviour
{

    public bool point = true;//マウスでのキャラ操作の切り替え
    public float sped=10f;//移動速度
    Vector2 mousePos;
    Vector2 mouseworldPos;//マウスポインタ位置
    public GameObject barte1;
    public GameObject barte2;
    public GameObject barte3;
    public GameObject barte4;
    private float wh;

 
    // Update is called once per frame
    void Update()
    {
        //マウスポインタの変換
        mousePos = Input.mousePosition;
        mouseworldPos = Camera.main.ScreenToWorldPoint(mousePos);

        

        if(point== true)//キャラ操作用
        {//マウスの位置へ向けて移動する
            transform.position = Vector2.MoveTowards(transform.position, mouseworldPos, sped * Time.deltaTime);  




        }

        
    }
    private void FixedUpdate()
    {
        Input.GetAxis("Mouse ScrollWheel");


    }
}
