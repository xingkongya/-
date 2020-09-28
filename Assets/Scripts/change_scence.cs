using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scence : MonoBehaviour
{
    public string 跳转场景名字;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void 场景跳转()
    {
        SceneManager.LoadScene(跳转场景名字);
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
