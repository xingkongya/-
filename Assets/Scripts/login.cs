using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    public void 结束游戏() {
        Application.Quit();
    }

    public void 猫王剧情()
    {
        SceneManager.LoadScene("猫王剧情_01");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 继续游戏() {
        SceneManager.LoadScene("mao_Home");
    }
}
