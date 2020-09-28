using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 人物战斗 : MonoBehaviour
{
    public bool 自动攻击=false;
    public int 等级;
    public int 血量;
    public int 攻击力;
    public int 防御力;
    public float 攻击速度;
    public float 攻击速度_初始=0;
    public int 剩余血量;
    public string 攻击目标名字="初始化";
    private GameObject 攻击目标;
    private int 扣血;
    private GameObject 扣血文本;
    private Slider 血条;
    public bool isAttack = false;
    private 怪物战斗 gw;
    private actor 人物属性;
    private actor_z_Bei 装备属性;
    private Vector3 攻击坐标;
    private Vector3 原来坐标;
    private int 总_攻击力;
    public int 总_防御力;
    private int 总_血量;
    private float 总_攻击速度;

    // Start is called before the first frame update
    void Awake()
    {
        读取数据();
        人物属性 = GameObject.Find("状态栏").GetComponent<actor>();
        人物属性.初始状态(this);
        //获取预制体
        扣血文本 = Resources.Load<GameObject>("Prefabs/扣血文本");
        血条 = gameObject.GetComponent<Slider>();
        原来坐标 = transform.position;
        攻击坐标 = new Vector3(transform.localPosition.x, transform.localPosition.y + 20, transform.localPosition.z);
        装备属性 = GameObject.Find("牧师").GetComponent<actor_z_Bei>();
        总属性刷新();
        血条.maxValue = 总_血量;
        剩余血量 = 总_血量;
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

        //位置的移动(模拟攻击动画)
        transform.position = Vector3.MoveTowards(transform.position, 原来坐标, 20);

        //判断攻击状态
        if (isAttack)
        {
            攻击目标 = GameObject.Find(攻击目标名字);
            //攻击目标丢失,停止攻击,攻击目标初始化(经优化,可删)
           /* if (攻击目标 == null)
            { 攻击目标 = GameObject.Find("初始化");
                isAttack = false;
            }*/
            gw = 攻击目标.GetComponent<怪物战斗>();

            ///
            /// 攻击
            ///
            //代码控制的攻击动画,有bug,待改进
            if (攻击速度_初始 <= 0)
            {
                攻击(gw);
                攻击速度_初始 = 总_攻击速度;
            }
            攻击速度_初始 -= Time.fixedDeltaTime;
        }


    }

    public void 总属性刷新() {
        Dictionary<string, float> 装备_属性 = 装备属性.装备属性加成();
        总_攻击力 =(int) 装备_属性["攻击力"] + 攻击力;
        总_防御力 =(int) 装备_属性["防御力"] + 防御力;
        总_血量 =(int) 装备_属性["血量"] + 血量;
        总_攻击速度 = (float)1.2 / (1 + 装备_属性["攻击速度"]);
    }

    public void 开启战斗()
    {
        isAttack = true;
    }

    public int 攻击(怪物战斗 gw)
    {
        transform.position = Vector3.MoveTowards(transform.position, 攻击坐标, 20);
        //判断怪物是否还有生命
        if (gw.剩余血量 > 0)
        {
            //攻击
            int 扣血_ = 总_攻击力 - gw.防御力;
            //判断是否破防,不破防伤害为0
            扣血 = 扣血_ >= 0 ? 扣血_ : 0;
            gw.扣血显示(扣血);
        }
        else {
            //自动攻击转移目标
            if (自动攻击)
            {

            }
        }
        gw.剩余血量 -= 扣血;
        return 扣血;
    }

    public void 猪脚失败() {
        isAttack = false;
        //黑屏动画

        //回家
        //SceneManager.LoadScene("mao_Home");
        return;
    }
    public void 扣血显示(int 扣血) {
        //怪物掉血
        //实例化预制体
        GameObject temp = GameObject.Instantiate(扣血文本);
        //实例化生成为怪物对象的子物体
        temp.transform.SetParent(gameObject.transform.parent.transform);
        //实例化坐标与缩放比例
        temp.transform.localPosition = new Vector3(transform.localPosition.x + 220, transform.localPosition.y, transform.localPosition.z);
        temp.transform.localScale = new Vector3(0.72f, 0.63f, 1);
        //扣血赋值
        temp.GetComponent<Text>().text = "-" + 扣血;
    }

    public void 读取数据() {
        //读取数据
        等级 = PlayerPrefs.GetInt("等级");
        攻击力 = PlayerPrefs.GetInt("攻击力");
        防御力 = PlayerPrefs.GetInt("防御力");
        血量 = PlayerPrefs.GetInt("血量");
        攻击速度 = PlayerPrefs.GetFloat("攻击速度"); ;
        //数据为空则赋值初始数据
        if (等级==0||攻击力 == 0 || 防御力 == 0 || 血量 == 0|| 攻击速度==0) {
            等级 = 1;
            攻击力 = 8;
            防御力 = 1;
            血量 = 50;
            攻击速度 = 1.2f;
        }
    }
}
