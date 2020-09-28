using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actor : MonoBehaviour
{
    private 人物战斗 rwzd;
    private Text 实时经验文本;
    private Slider 经验条;
    private int 当前经验=0;

    // Start is called before the first frame update
    void Start()
    {
        rwzd = gameObject.transform.parent.transform.Find("牧师").GetComponent<人物战斗>();
        实时经验文本 = gameObject.transform.Find("拓展栏").transform.Find("经验文本").GetComponent<Text>();
        经验条 = gameObject.transform.Find("经验条").GetComponent<Slider>();
        经验读取();

    }
    void Update()
    {
        


    }
    public void 属性栏数值显示() {
        Text 数值文本 = gameObject.transform.Find("拓展栏").transform.Find("属性数值").GetComponent<Text>();
        数值文本.text = "人物: 牧师    \n等级: " + rwzd.等级+"\n攻击力: "+rwzd.攻击力+"     "+"\n防御力: "+rwzd.防御力+"\n血量: "+rwzd.血量+"     "+"\n攻速:"+rwzd.攻击速度;
    }

    int 经验表(int 等级) {
        //正则查询错误数据

        //所需经验值=基础经验+十等级进位增长值+总等级增长值
        int 所需经验值 = 50 + ((int)Math.Pow(4, Math.Ceiling((Double)等级/10)))+((等级*(等级-1))*33);
        return 所需经验值;
    }

    void 经验文本刷新() {
        实时经验文本.text = "当前经验: " + 当前经验 + " / " + 经验表(rwzd.等级);
    }
    void 经验条刷新(){
        经验条.maxValue = 经验表(rwzd.等级);
        经验条.value = 当前经验;
    }

    public void 当前经验增加(int 经验值) {
        int 当前等级所需经验 = 经验表(rwzd.等级);
        当前经验 += 经验值;
        if (当前经验>= 当前等级所需经验) {
            当前经验 -= 当前等级所需经验;
            rwzd.等级 += 1;
            人物升级();
            属性栏数值显示();
            初始状态(rwzd);
        }
        经验存储();
        经验文本刷新();
        经验条刷新();
    }

    public void 初始状态(人物战斗 rwzd) {
        Text 初始文本 = gameObject.transform.Find("初始状态").GetComponent<Text>();
        初始文本.text = "人物: 牧师       等级: " + rwzd.等级;
        //经验文本刷新();
        //经验条刷新();
    }

    public void 人物升级() {
        //升级效果

        rwzd.攻击力 += 3;
        rwzd.防御力 += 1;
        rwzd.血量 += 10;
        rwzd.剩余血量 = rwzd.血量;
        数据存储();
        rwzd.总属性刷新();
    }

    public void 数据存储() {
        //数据存储
        PlayerPrefs.SetInt("等级", rwzd.等级);
        PlayerPrefs.SetInt("攻击力", rwzd.攻击力);
        PlayerPrefs.SetInt("防御力", rwzd.防御力);
        PlayerPrefs.SetInt("血量", rwzd.血量);
        PlayerPrefs.SetFloat("攻击速度", rwzd.攻击速度);
        

    }
    public void 经验读取() {
        当前经验=PlayerPrefs.GetInt("当前经验值");
        经验文本刷新();
        经验条刷新();
    }

    public void 经验存储()
    {
        PlayerPrefs.SetInt("当前经验值", 当前经验);
    }
}
