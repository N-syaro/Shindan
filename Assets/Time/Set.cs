using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Set : MonoBehaviour
{
    public GameObject Timeobject;

    public void St()//タイマーを表示させるとき呼び出す
    {
        Timeobject.SetActive(true);
    }

}
