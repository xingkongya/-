using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 神秘巨岩 : MonoBehaviour
{
    private Ji_Guan jg;
    private GameObject 隐藏地图;
    // Start is called before the first frame update
    void Start()
    {
        jg = GameObject.Find("画布").GetComponent<Ji_Guan>();
        隐藏地图 = GameObject.Find("地图系统/移动系统/箭头/箭头_左").gameObject;
    }
    private void OnDisable()
    {
        jg.溪流河机关(隐藏地图);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
