using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class first_徐州城 : MonoBehaviour
{

    int num = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=2;i<=12;i++) {
            GameObject.Find("T_" + i).transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }

    public void 单击显示剧情()
    {
        if (num<12) {
            num++;
            //用Find损耗性能,有待优化
            GameObject.Find("T_" + num).transform.GetChild(0).gameObject.SetActive(true);
            //显示第六句时把前五句屏蔽
            if (num == 6) {
                for (int i = 1; i <= 5; i++)
                {
                    GameObject.Find("T_" + i).transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //显示第八句时把前两句屏蔽
            if (num == 8) {
                for (int i = 6; i <= 7; i++)
                {
                    GameObject.Find("T_" + i).transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //显示第九句时把第八句屏蔽
            if (num == 9)
                GameObject.Find("T_8").transform.GetChild(0).gameObject.SetActive(false);
            //显示第十句时把第九句屏蔽
            if (num == 10)
                GameObject.Find("T_9").transform.GetChild(0).gameObject.SetActive(false);

        }
    }

    public void 重新看() {
        num = 1;
        SceneManager.LoadScene("小黄剧情_01");
        return;
    }

    public void 选择1() { 选择(1); }
    public void 选择2() { 选择(2); }

    public void 选择3() { 选择(3); }

    void 选择(int num) {
        int 好感;
        if (num==1) 
            好感 = 30;
        else if(num == 2)
            好感 = -10;
        else
            好感 = 0;
        PlayerPrefs.SetInt("小黄好感度", 好感);
        PlayerPrefs.SetInt("初来徐州", 1);
        SceneManager.LoadScene("徐州城南");
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
