using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class 地图怪物_工具 : MonoBehaviour
{
    public string 当前怪物属性脚本名;
    public int 怪物1出现概率;
    public int 怪物2出现概率;
    public int 怪物3出现概率;
    public int 怪物4出现概率;
    public string 怪物名字;
    public bool 是否主动攻击;
    public int 最低等级;
    public int 最高等级;
    private int 随机数等级;
    public int 基础攻击力;
    public int 基础防御力;
    public int 基础血量;
    public int 血量成长;
    public int 攻击力成长;
    public int 防御力成长;
    public float 攻击速度;
    private 怪物战斗 gwzd;
    private 怪物属性 gwsx;
    



    // Start is called before the first frame update
    void Start()
    {
        //获取当前场景中的怪物属性脚本
        gwsx =(怪物属性) gameObject.transform.GetComponent(当前怪物属性脚本名);
        //获取所有怪物预制体中的怪物战斗脚本
        GameObject[] 怪物预制体们 = GameObject.FindGameObjectsWithTag("怪物");
        for (int i=0;i< 怪物预制体们.Length;i++) {
            gwzd = 怪物预制体们[i].GetComponent<怪物战斗>();
        }
    }

 

    public void 怪物赋值(怪物战斗 gwzd) {
        Random 随机类 = new Random();
        int 随机数= 随机类.Next(1,100);
        //本类属性赋值;
        if (随机数 >= 1 && 随机数 <= 怪物1出现概率)
        {
            gwsx.怪物一赋值(this);
        }
        else if (随机数 >= 怪物1出现概率 && 随机数 <= 怪物1出现概率 + 怪物2出现概率)
        {
            gwsx.怪物二赋值(this);
        }
        else if (怪物1出现概率 + 怪物2出现概率 >= 随机数 && 随机数 <= 怪物1出现概率 + 怪物2出现概率 + 怪物3出现概率)
        {
            gwsx.怪物三赋值(this);
        }
        else {
            gwsx.怪物四赋值(this);
        }
        //等级随机
        if (最低等级 == 最高等级)
        {
            随机数等级 = 最低等级;
        }
        else {
            随机数等级 = 随机类.Next(最低等级,最高等级);
        }
        //怪物战斗脚本属性赋值
        gwzd.主动攻击 = 是否主动攻击;
        gwzd.等级 = 随机数等级;
        gwzd.血量 = 基础血量 + 随机数等级 * 血量成长;
        gwzd.攻击力= 基础攻击力 + 随机数等级 * 攻击力成长;
        gwzd.防御力 = 基础防御力 + 随机数等级 * 防御力成长;

        //怪物名字赋值与变色
        Text 名字文本=gwzd.gameObject.transform.Find("按钮").transform.Find("名字").GetComponent<Text>();
        名字文本.text = 怪物名字;
    }
   

}
