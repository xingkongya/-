using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 城门小道怪物属性 : MonoBehaviour,怪物属性
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
        dtgw.怪物名字 = "野狗";
        dtgw.怪物位阶 = 1;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 5;
        dtgw.最高等级 = 10;
        dtgw.基础攻击力 = 8;
        dtgw.基础防御力 = 0;
        dtgw.基础血量 = 40;
        dtgw.攻击力成长 = 2;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 7;
        dtgw.攻击速度 = 2;
        dtgw.基础经验 = 30;
        dtgw.经验系数 = 3;
        dtgw.必掉材料 = "狗骨头";

    }


    public void 怪物二赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "疯狗";
        dtgw.怪物位阶 = 2;
        dtgw.是否主动攻击 = true;
        dtgw.最低等级 = 5;
        dtgw.最高等级 = 10;
        dtgw.基础攻击力 = 10;
        dtgw.基础防御力 = 2;
        dtgw.基础血量 = 60;
        dtgw.攻击力成长 = 4;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 10;
        dtgw.攻击速度 = 1.5f;
        dtgw.基础经验 = 120;
        dtgw.经验系数 = 5;
        dtgw.必掉材料 = "狗牙";
    }

    public void 怪物三赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "夜狼";
        dtgw.怪物位阶 = 2;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 5;
        dtgw.最高等级 = 10;
        dtgw.基础攻击力 = 12;
        dtgw.基础防御力 = 2;
        dtgw.基础血量 = 80;
        dtgw.攻击力成长 = 3;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 12;
        dtgw.攻击速度 = 2f;
        dtgw.基础经验 = 130;
        dtgw.经验系数 = 5;
        dtgw.必掉材料 = "优质狼皮";

    }

    public void 怪物四赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "山君";
        dtgw.怪物位阶 = 3;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 10;
        dtgw.最高等级 = 10;
        dtgw.基础攻击力 = 15;
        dtgw.基础防御力 = 8;
        dtgw.基础血量 = 300;
        dtgw.攻击力成长 = 6;
        dtgw.防御力成长 = 1;
        dtgw.血量成长 = 35;
        dtgw.攻击速度 = 1.5f;
        dtgw.基础经验 = 300;
        dtgw.经验系数 = 18;
        dtgw.必掉材料 = "山魄";

    }

}
