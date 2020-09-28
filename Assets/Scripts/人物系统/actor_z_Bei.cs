using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class actor_z_Bei : MonoBehaviour
{
    private List<string> 装备位置 = new List<string> { "武器`", "头部", "衣服", "足部", "饰品", "左卡", "右卡" };
    private Color 品质颜色;
    private 人物战斗 rwzd;
    private actor 人物面板;

    // Start is called before the first frame update
    void Start()
    {
        rwzd = GameObject.Find("牧师").GetComponent<人物战斗>();
        人物面板 = GameObject.Find("牧师").GetComponent<actor>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void 穿装备(Good_equipment 装备) {
        string str_装备 = JsonMapper.ToJson(装备);
        //ui效果
        Text 装备位置 = GameObject.Find(装备.get_位置).GetComponent<Text>();
        装备位置.text = 装备.get_name;
        装备位置.color = 装备颜色(装备.get_品质);
        //储存
        PlayerPrefs.SetString(装备.get_位置, str_装备);
        //战斗属性刷新
        rwzd.总属性刷新();
        //属性页面记得刷新
        人物面板.属性栏数值显示();
    }

    Color 装备颜色(string 品质) {
        if (品质.Equals("普通"))
            ColorUtility.TryParseHtmlString("#323232", out 品质颜色);
        else if (品质.Equals("精良"))
            ColorUtility.TryParseHtmlString("#489A5A", out 品质颜色);
        else if (品质.Equals("优质"))
            ColorUtility.TryParseHtmlString("#2F97CB", out 品质颜色);
        else if (品质.Equals("稀有"))
            ColorUtility.TryParseHtmlString("#CC44C1", out 品质颜色);
        else if (品质.Equals("传说"))
            ColorUtility.TryParseHtmlString("#E98819", out 品质颜色);
        else if (品质.Equals("神话"))
            ColorUtility.TryParseHtmlString("#E92719", out 品质颜色);

        return 品质颜色;
    }

    public Dictionary<string, float> 装备属性加成() {
        int 攻击力 = 0;
        int 防御力 = 0;
        int 血量 = 0;
        float 攻速 = 0;
        foreach (string 位置 in 装备位置) {
            if (!PlayerPrefs.GetString(位置).Equals("")) {
                Good_equipment 装备 = JsonMapper.ToObject<Good_equipment>(PlayerPrefs.GetString(位置));
                攻击力 += 装备.get_攻击;
                防御力 += 装备.get_防御;
                血量 += 装备.get_血量;
                攻速 += 装备.get_攻速;
            }
        }
        Dictionary<string, float> 装备属性 = new Dictionary<string, float>();
        装备属性.Add("攻击力", 攻击力);
        装备属性.Add("防御力", 防御力);
        装备属性.Add("血量", 血量);
        装备属性.Add("攻击速度", 攻速);
        return 装备属性;
    }
    
}
