using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 人物属性 : MonoBehaviour
{
    public bool 自动攻击=false;
    public int 等级;
    public int 血量;
    public int 攻击力;
    public int 防御力;
    public float 攻击速度;
    private float 攻击速度_初始=0;
    public int 剩余血量;
    public string 攻击目标名字="初始化";
    private GameObject 攻击目标;
    private int 扣血;
    private Slider 血条;
    public bool isAttack = false;
    private 怪物属性 gw;
    private Vector3 攻击坐标;
    private Vector3 原来坐标;
    private 扣血显示 kxxs;
    // Start is called before the first frame update
    void Start()
    {
        血条 = gameObject.GetComponent<Slider>();
        血条.maxValue = 血量;
        原来坐标 = transform.position;
        攻击坐标 = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        血条.value = 剩余血量;

        //判断自己是否还有生命
        if (剩余血量 <= 0)
        {
            猪脚失败();
        }

        transform.position = Vector3.MoveTowards(transform.position, 原来坐标, 20);
        //判断攻击状态
        if (isAttack)
        {
            攻击目标 = GameObject.Find(攻击目标名字);
            //攻击目标丢失,停止攻击,攻击目标初始化
            if (攻击目标 == null)
            { 攻击目标 = GameObject.Find("初始化");
                isAttack = false;
            }
            gw = 攻击目标.GetComponent<怪物属性>();
            kxxs = 攻击目标.transform.Find("扣血_怪物").GetComponent<扣血显示>();

            ///
            /// 攻击
            ///
            //代码控制的攻击动画,有bug,待改进
            if (攻击速度_初始 <= 0)
            {
                攻击(gw);
                攻击速度_初始 = 攻击速度;
            }
            攻击速度_初始 -= Time.fixedDeltaTime;
        }


    }

    public void 开启战斗()
    {
        isAttack = true;
    }

    public int 攻击(怪物属性 gw)
    {
        transform.position = Vector3.MoveTowards(transform.position, 攻击坐标, 20);
        //判断怪物是否还有生命
        if (gw.剩余血量 > 0)
        {
            //攻击
            int 扣血_ = 攻击力 - gw.防御力成长 * gw.等级;
            //判断是否破防,不破防伤害为0
            扣血 = 扣血_ >= 0 ? 扣血_ : 0;
            kxxs.扣血 = 扣血;
        }
        else {
            if (自动攻击)
            {

            }
            else isAttack = false;
        }
        gw.剩余血量 -= 扣血;

        return 扣血;
    }

    public void 猪脚失败() {
        gw.isAttack = false;
        isAttack = false;
        //黑屏动画

        //回家
        //SceneManager.LoadScene("mao_Home");
        return;
    }
}
