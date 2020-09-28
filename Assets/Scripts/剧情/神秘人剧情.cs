using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 神秘人剧情 : MonoBehaviour
{
    private int smr_num;
    public GameObject 对话框;
    public GameObject 剧情框;
    public GameObject 箭头;
    private GameObject bt_0;
    private GameObject bt_1;
    private GameObject bt_2;
    private string str_0;
    private string str_1;
    private string str_2;
    private string str_3;

    // Start is called before the first frame update
    void Start()
    {
        smr_num = PlayerPrefs.GetInt("神秘人剧情点击数");
        bt_0 = 对话框.transform.Find("bt_0").gameObject;
        bt_1 = 对话框.transform.Find("bt_1").gameObject;
        bt_2 = 对话框.transform.Find("bt_2").gameObject;
        str_0 = "你可以称呼吾为神, 你现在拥有的力量来源于吾.";
        str_1 = "所有的力量皆有源头, 喵喵是只获得吾部分力量的猫. 不过多亏了它, 吾才发现了与我力量契合度最高的你.";
        str_2 = "这种力量叫魂力, 它会使你更加强大. 同样你用它杀死敌人, 并吸收敌人的魂力会变的更强. 而且敌人有小几率掉落魂石, 你可以用它来赋予生命. 所以理论上只要你够强, 喵喵也是能复活的";
        str_3 = "打败你的仇人再来找我吧, 吾会给你一个惊喜的!";
        if (smr_num>=3) {
            箭头.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick_Num() {
        if (对话框.activeSelf) {
            对话框.SetActive(false);
        }
        else {
            if (smr_num == 0)
                bt_0.SetActive(true);
            else if(smr_num == 1)
                bt_1.SetActive(true);
            else if (smr_num == 2)
                bt_2.SetActive(true);
            else
            {
                over_对话();
                箭头.SetActive(true);
                return;
            }


            对话框.SetActive(true);
            return;
        }
    }

    public void fir_对话(GameObject 对话框) {
        剧情框.GetComponent<文字逐渐打印>().str = str_0;
        对话(对话框);
        对话框.transform.Find("bt_0").gameObject.SetActive(false);
    }

    public void no1_对话(GameObject 对话框)
    {
        剧情框.GetComponent<文字逐渐打印>().str = str_1;
        对话(对话框);
        对话框.transform.Find("bt_1").gameObject.SetActive(false);
    }

    public void no2_对话(GameObject 对话框)
    {
        剧情框.GetComponent<文字逐渐打印>().str = str_2;
        对话(对话框);
        对话框.transform.Find("bt_2").gameObject.SetActive(false);
    }

    public void over_对话()
    {
        剧情框.GetComponent<文字逐渐打印>().str = str_3;
        对话(对话框);
    }

    public void 对话(GameObject 对话框) {
        剧情框.SetActive(true);
        对话框.SetActive(false);
       
    }

    public void 清除剧情框() {
        smr_num++;
        PlayerPrefs.SetInt("神秘人剧情点击数", smr_num);
        剧情框.transform.Find("对话").GetComponent<Text>().text = "";

    }

    public void 场景跳转()
    {
        PlayerPrefs.SetInt("神秘人剧情点击数", smr_num);
        SceneManager.LoadScene("村口小道");
        return;
    }

    public void 剧情清除() {
        //待补充
        if (PlayerPrefs.GetInt("神秘人剧情点击数")!=0) {
            PlayerPrefs.DeleteKey("神秘人剧情点击数");
            PlayerPrefs.DeleteKey("初来徐州");
            PlayerPrefs.DeleteKey("小黄好感度");
        }
        SceneManager.LoadScene("猫王剧情_01");
    
    }
}
