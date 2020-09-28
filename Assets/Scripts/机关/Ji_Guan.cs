using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ji_Guan : MonoBehaviour
{
    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void 溪流河机关(GameObject 隐藏地图 ) {
        num++;
        if (num==2) {
            隐藏地图.SetActive(true);
        }
    }
}
