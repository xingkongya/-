using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 猫王剧情_01 : MonoBehaviour
{
    int num = 1;

    public void 单击显示剧情() {
        if (num >= 6)
        {
            SceneManager.LoadScene("猫王剧情_02");
            return;
        }

        //用Find损耗性能,有待优化
        GameObject.Find(num+"_").transform.Find(num+"").gameObject.SetActive(true);
        num++;
        
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
