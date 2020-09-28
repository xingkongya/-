using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipment_activity : MonoBehaviour
{
    private int page_num = 1;
    private GameObject 兑换装备信息;
    private GameObject 上一页;
    private GameObject 下一页;
    private Text 装备1;
    private Text 装备2;
    private Text 装备3;
    private Text 装备4;
    // Start is called before the first frame update
    void Awake()
    {
        兑换装备信息 = GameObject.Find("兑换装备信息");
        上一页 = GameObject.Find("画布/活动/装备兑换活动/页面操作/上一页").gameObject;
        下一页 = GameObject.Find("画布/活动/装备兑换活动/页面操作/下一页").gameObject;
        装备1 = 兑换装备信息.transform.Find("装备1").GetComponent<Text>();
        装备2 = 兑换装备信息.transform.Find("装备2").GetComponent<Text>();
        装备3 = 兑换装备信息.transform.Find("装备3").GetComponent<Text>();
        装备4 = 兑换装备信息.transform.Find("装备4").GetComponent<Text>();
    }


    void OnEnable()
    {
        第一页赋值();
        上一页.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 下页() {
        page_num++;
        跳页(page_num);
    }
    public void 上页()
    {
        page_num--;
        跳页(page_num);
    }

    private void 跳页(int page_num_) {
        switch (page_num_)
        {
            case 1:
                第一页赋值();
                上一页.SetActive(false);
                break;
            case 2:
                第二页赋值();
                上一页.SetActive(true);
                break;
            case 3:
                第三页赋值();
                break;
            case 4:
                第四页赋值();
                下一页.SetActive(true);
                break;
            case 5:
                第五页赋值();
                下一页.SetActive(false);
                break;
        }

    }

    void 第一页赋值() {
        装备1.text = "<令箭>     位置:武器                    最低使用等级:1级         品级:普通\n效果:\n攻击力 + 5\n合成需求: 10片鸡毛\n当前进度: ";
        装备2.text = "<羽冠>     位置:头部                    最低使用等级:1级         品级:普通\n效果:\n生命值 + 30\n合成需求: 10片鸡毛, 3个鸡冠\n当前进度: ";
        装备3.text = "<羽衣>     位置:衣服                    最低使用等级:1级         品级:普通\n效果:\n防御力 + 3\n合成需求: 15片鸡毛, 2个鸡蛋\n当前进度: ";
        装备4.text = "<彩の羽>     位置:饰品                    最低使用等级:1级         品级:稀有\n效果:\n攻击力 + 5, 防御力+2, 生命值+20, 攻击速度+10%\n合成需求: 1片七彩羽\n当前进度: ";
    }
    void 第二页赋值()
    {
        装备1.text = "<铁剑>     位置:武器                    最低使用等级:5级         品级:普通\n效果:\n攻击力 + 10\n合成需求: 15个狗骨头\n当前进度: ";
        装备2.text = "<皮盔>     位置:头部                    最低使用等级:5级         品级:普通\n效果:\n生命值 + 60\n合成需求: 10个狗骨头, 3个狗牙\n当前进度: ";
        装备3.text = "<皮衣>     位置:衣服                    最低使用等级:5级         品级:普通\n效果:\n防御力 + 6\n合成需求: 10个狗骨头, 3个优质狼皮\n当前进度: ";
        装备4.text = "<山御>     位置:饰品                    最低使用等级:5级         品级:稀有\n效果:\n攻击力 +15, 防御力 + 10\n合成需求: 1个山魄\n当前进度: ";
    }
    void 第三页赋值()
    {
        装备1.text = "<勇者剑>     位置:武器                    最低使用等级:10级         品级:普通\n效果:\n攻击力 + 18\n合成需求: 10片鸡毛\n当前进度: ";
        装备2.text = "<勇者头盔>     位置:头部                    最低使用等级:10级         品级:普通\n效果:\n生命值 + 100\n合成需求: 10片鸡毛, 3个鸡冠\n当前进度: ";
        装备3.text = "<勇者衣>     位置:衣服                    最低使用等级:10级         品级:普通\n效果:\n防御力 + 10\n合成需求: 15片鸡毛, 2个鸡蛋\n当前进度: ";
        装备4.text = "<守护之心>     位置:饰品                    最低使用等级:10级         品级:稀有\n效果:\n防御力 + 30\n合成需求: 1片七彩羽\n当前进度: ";
    }
    void 第四页赋值()
    {
        装备1.text = "<荆棘剑>     位置:武器                    最低使用等级:15级         品级:普通\n效果:\n攻击力 + 30\n合成需求: 10片鸡毛\n当前进度: ";
        装备2.text = "<荆棘盔>     位置:头部                    最低使用等级:15级         品级:普通\n效果:\n生命值 + 180\n合成需求: 10片鸡毛, 3个鸡冠\n当前进度: ";
        装备3.text = "<荆棘甲>     位置:衣服                    最低使用等级:15级         品级:普通\n效果:\n防御力 + 18\n合成需求: 15片鸡毛, 2个鸡蛋\n当前进度: ";
        装备4.text = "<精灵之翼>     位置:饰品                    最低使用等级:15级         品级:稀有\n效果:\n攻击力 + 40, 攻击速度+10%\n合成需求: 1片七彩羽\n当前进度: ";
    }
    void 第五页赋值()
    {
        装备1.text = "<出云剑>     位置:武器                    最低使用等级:20级         品级:普通\n效果:\n攻击力 + 45\n合成需求: 10片鸡毛\n当前进度: ";
        装备2.text = "<出云盔>     位置:头部                    最低使用等级:20级         品级:普通\n效果:\n生命值 + 260\n合成需求: 10片鸡毛, 3个鸡冠\n当前进度: ";
        装备3.text = "<出云服>     位置:衣服                    最低使用等级:20级         品级:普通\n效果:\n防御力 + 26\n合成需求: 15片鸡毛, 2个鸡蛋\n当前进度: ";
        装备4.text = "<出云玉佩>     位置:饰品                    最低使用等级:20级         品级:稀有\n效果:\n攻击速度+25%\n合成需求: 1片七彩羽\n当前进度: ";
    }



}
