using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 村口小道怪物属性 : MonoBehaviour,怪物属性
{

    private 地图怪物_工具 dtgw;
    private string 怪物名字;
    private bool 是否主动攻击;
    private int 最低等级;
    private int 最高等级;
    private int 基础攻击力;
    private int 基础防御力;
    private int 基础血量;
    private int 攻击力成长;
    private int 防御力成长;
    private int 血量成长;
    private float 攻击速度;




    public void 怪物一赋值(地图怪物_工具 dtgw) {
        dtgw.怪物名字 = "小鸡";
        dtgw.怪物位阶 = 1;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 1;
        dtgw.最高等级 = 5;
        dtgw.基础攻击力 = 5;
        dtgw.基础防御力 = 0;
        dtgw.基础血量 = 10;
        dtgw.攻击力成长 = 2;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 5;
        dtgw.攻击速度 = 2;
        dtgw.基础经验 = 10;
        dtgw.经验系数 = 2;

    }


    public void 怪物二赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "老母鸡";
        dtgw.怪物位阶 = 2;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 3;
        dtgw.最高等级 = 5;
        dtgw.基础攻击力 = 8;
        dtgw.基础防御力 = 2;
        dtgw.基础血量 = 25;
        dtgw.攻击力成长 = 3;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 8;
        dtgw.攻击速度 = 1.8f;
        dtgw.基础经验 = 40;
        dtgw.经验系数 = 3;

    }

    public void 怪物三赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "大公鸡";
        dtgw.怪物位阶 = 2;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 3;
        dtgw.最高等级 = 5;
        dtgw.基础攻击力 = 8;
        dtgw.基础防御力 = 2;
        dtgw.基础血量 = 25;
        dtgw.攻击力成长 = 4;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 6;
        dtgw.攻击速度 = 2f;
        dtgw.基础经验 = 40;
        dtgw.经验系数 = 3;

    }

    public void 怪物四赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "七彩羽鸡";
        dtgw.怪物位阶 = 3;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 5;
        dtgw.最高等级 = 5;
        dtgw.基础攻击力 = 10;
        dtgw.基础防御力 = 5;
        dtgw.基础血量 = 100;
        dtgw.攻击力成长 = 5;
        dtgw.防御力成长 = 1;
        dtgw.血量成长 = 20;
        dtgw.攻击速度 = 1.2f;
        dtgw.基础经验 = 100;
        dtgw.经验系数 = 10;

    }

}
