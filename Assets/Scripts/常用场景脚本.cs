using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 常用场景脚本 : MonoBehaviour
{
    public string 场景名字;
    private 怪物属性 gwsx;
 

    public void 场景跳转()
    {
        SceneManager.LoadScene(场景名字);
        return;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
