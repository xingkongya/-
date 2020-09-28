using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 扣血显示 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //1秒后销毁
        Destroy(this.gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //移动效果
        if (gameObject.transform.parent.name.Equals("牧师_all"))
            transform.Translate(Vector3.down * Time.deltaTime * 25f);
        else 
            transform.Translate(Vector3.up * Time.deltaTime * 25f);
    }

}
