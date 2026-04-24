using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    [SerializeField]
    public Image image;


  
    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
        image.gameObject.SetActive(true);
        }
    }


}
