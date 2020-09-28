using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 怪物战斗 : MonoBehaviour
{
    //基础数据类型区
    public bool 主动攻击 = false;
    public int 等级;
    public int 血量;
    public int 攻击力;
    public int 防御力;
    public float 攻击速度;
    private float 攻击速度_初始 = 0;
    public int 剩余血量;
    public int 经验值;
    public string 必掉材料;
    private bool isAttack = false;
    private int 扣血;
    //引用数据类型区
    private GameObject 攻击目标;
    private GameObject 扣血文本;
    private Slider 血条;
    private Color nowColor;
    private Vector3 攻击坐标;
    private Vector3 原来坐标;
    //自写脚本区
    private 常用场景脚本 常用场景脚本;
    private 地图怪物_工具 dtgw;
    private actor 人物属性;
    private 人物战斗 rw;
    private get_monster g_m;
    // Start is called before the first frame update
    void Start()
    {
        //获取预制体
        扣血文本 = Resources.Load<GameObject>("Prefabs/扣血文本");
        血条 = gameObject.GetComponent<Slider>();
        dtgw = GameObject.Find("画布").GetComponent<地图怪物_工具>();
        常用场景脚本 = GameObject.Find("画布").GetComponent<常用场景脚本>();
        人物属性 = GameObject.Find("牧师_all").transform.Find("状态栏").GetComponent<actor>();
        g_m = gameObject.transform.parent.gameObject.GetComponent<get_monster>();
        if (gameObject.tag.Equals("怪物")) 初始化();
        原来坐标 = transform.position;
        攻击坐标 = new Vector3(transform.localPosition.x, transform.localPosition.y - 10, transform.localPosition.z);
        攻击目标 = GameObject.Find("牧师");
        rw = 攻击目标.GetComponent<人物战斗>();
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

        //位置的移动(模拟攻击动画)
        transform.position = Vector3.MoveTowards(transform.position, 原来坐标, 20);
      
        //判断攻击状态
        if (isAttack&&gameObject.tag.Equals("怪物"))
        {

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

    private void OnDisable()
    {
        if(gameObject.tag.Equals("怪物")) g_m.开始刷新();
    }


    public string 返回怪物名() {
        return gameObject.name;
    }

    public string 开启战斗()
    {
        isAttack = true;
        //战斗黄
        ColorUtility.TryParseHtmlString("#D2C13F", out nowColor);
        gameObject.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = nowColor;
        return gameObject.name;
    }

    int 攻击(人物战斗 rw)
    {
        transform.position = Vector3.MoveTowards(transform.position, 攻击坐标, 20);
        //判断人物是否还有生命
        if (rw.剩余血量 > 0)
        {
            //攻击
            int 扣血_ = 攻击力 - rw.总_防御力; ;
            //判断是否破防,不破防伤害为0
            扣血 = 扣血_ >= 0 ? 扣血_ : 0;
            rw.扣血显示(扣血);
            
        }
        else  isAttack = false;
        rw.剩余血量 -= 扣血;

        return 扣血;
    }

     void 怪物失败()
    {
        if (gameObject.tag.Equals("怪物"))
        {
            //怪物死亡重置普攻
            rw.攻击速度_初始 = 0;
            isAttack = false;
            //获取经验,物品
            人物属性.当前经验增加(经验值);
            string str = "经验: +" + 经验值;
            常用场景脚本.获取经验特效(str);
            if (!必掉材料.Equals(""))
            {
                //持久化
                常用场景脚本.物品持久化(必掉材料, 1);
                string str1 = "获得: " + 必掉材料;
                常用场景脚本.获取物品特效(str1);
            }
        }
        rw.isAttack = false;
        gameObject.SetActive(false);
    }

    public void 初始化() {

        dtgw.怪物赋值(this);
        血条.maxValue = 血量;
        剩余血量 = 血量;
        //判断是否主动攻击
        if (主动攻击)
        {
            开启战斗();
        }
    }

    public void 扣血显示(int 扣血){
        //怪物掉血
        //实例化预制体
        GameObject temp = GameObject.Instantiate(扣血文本);
        //实例化生成为怪物对象的子物体
        temp.transform.SetParent(gameObject.transform.parent.transform);
        //实例化坐标与缩放比例
        temp.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+50, transform.localPosition.z);
        temp.transform.localScale = new Vector3(0.72f, 0.63f, 1);
        //扣血赋值
        temp.GetComponent<Text>().text = "-"+扣血;
    }


}
