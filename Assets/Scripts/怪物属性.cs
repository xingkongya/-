using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 怪物属性 : MonoBehaviour
{
    public int 等级;
    public int 血量成长;
    public int 攻击力成长;
    public int 防御力成长;
    public float 攻击速度;
    private float 攻击速度_初始 = 0;
    public int 剩余血量;
    private GameObject 攻击目标;
    private int 扣血;
    private Slider 血条;
    private Color nowColor;
    public bool isAttack = false;
    private 人物属性 rw;
    private Vector3 攻击坐标;
    private Vector3 原来坐标;
    private 扣血显示 kxxs;
    // Start is called before the first frame update
    void Start()
    {
        血条 = gameObject.GetComponent<Slider>();
        血条.maxValue = 血量成长*等级;
        原来坐标 = transform.position;
        攻击坐标 = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
        攻击目标 = GameObject.Find("牧师");
        rw = 攻击目标.GetComponent<人物属性>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        血条.value = 剩余血量;

        //判断自己是否还有生命
        if (剩余血量 <= 0)
        {
            怪物失败();
        }

        transform.position = Vector3.MoveTowards(transform.position, 原来坐标, 20);
        //判断攻击状态
        if (isAttack)
        {
            kxxs = 攻击目标.transform.Find("扣血_猪脚").GetComponent<扣血显示>();

            ///
            /// 攻击
            ///
            //代码控制的攻击动画,有bug,待改进
            if (攻击速度_初始 <= 0)
            {
                攻击(rw);
                攻击速度_初始 = 攻击速度;
            }
            攻击速度_初始 -= Time.fixedDeltaTime;
        }
        else {
            //停战绿
            ColorUtility.TryParseHtmlString("#3A8E3B", out nowColor);
            gameObject.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = nowColor;
        }


    }

    public string 开启战斗()
    {
        isAttack = true;
        //战斗黄
        ColorUtility.TryParseHtmlString("#D2C13F", out nowColor);
        gameObject.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = nowColor;
        return gameObject.name;
    }

    public int 攻击(人物属性 rw)
    {
        transform.position = Vector3.MoveTowards(transform.position, 攻击坐标, 20);
        //判断怪物是否还有生命
        if (rw.剩余血量 > 0)
        {
            //攻击
            int 扣血_ = 攻击力成长 * 等级 - rw.防御力;
            //判断是否破防,不破防伤害为0
            扣血 = 扣血_ >= 0 ? 扣血_ : 0;
            kxxs.扣血 = 扣血;
        }
        else  isAttack = false;
        rw.剩余血量 -= 扣血;

        return 扣血;
    }

    public void 怪物失败()
    {
        isAttack = false;
        gameObject.SetActive(false);
    }
}
