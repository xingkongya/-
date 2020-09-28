using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 溪流河边怪物属性 : MonoBehaviour,怪物属性
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
        dtgw.怪物名字 = "河童";
        dtgw.怪物位阶 = 1;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 10;
        dtgw.最高等级 = 15;
        dtgw.基础攻击力 = 12;
        dtgw.基础防御力 = 0;
        dtgw.基础血量 = 120;
        dtgw.攻击力成长 = 3;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 9;
        dtgw.攻击速度 = 1.8f;
        dtgw.基础经验 = 80;
        dtgw.经验系数 = 2;
        dtgw.必掉材料 = "莲叶";

    }


    public void 怪物二赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "虾兵";
        dtgw.怪物位阶 = 2;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 10;
        dtgw.最高等级 = 15;
        dtgw.基础攻击力 = 15;
        dtgw.基础防御力 = 3;
        dtgw.基础血量 = 200;
        dtgw.攻击力成长 = 6;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 15;
        dtgw.攻击速度 = 1.6f;
        dtgw.基础经验 = 180;
        dtgw.经验系数 = 6;
        dtgw.必掉材料 = "鲜虾";

    }

    public void 怪物三赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "蟹将";
        dtgw.怪物位阶 = 2;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 10;
        dtgw.最高等级 = 15;
        dtgw.基础攻击力 = 8;
        dtgw.基础防御力 = 5;
        dtgw.基础血量 = 250;
        dtgw.攻击力成长 = 6;
        dtgw.防御力成长 = 0;
        dtgw.血量成长 = 25;
        dtgw.攻击速度 = 2f;
        dtgw.基础经验 = 190;
        dtgw.经验系数 = 6;
        dtgw.必掉材料 = "大闸蟹";

    }

    public void 怪物四赋值(地图怪物_工具 dtgw)
    {
        dtgw.怪物名字 = "蛟守";
        dtgw.怪物位阶 = 3;
        dtgw.是否主动攻击 = false;
        dtgw.最低等级 = 15;
        dtgw.最高等级 = 15;
        dtgw.基础攻击力 = 25;
        dtgw.基础防御力 = 10;
        dtgw.基础血量 = 500;
        dtgw.攻击力成长 = 5;
        dtgw.防御力成长 = 2;
        dtgw.血量成长 = 45;
        dtgw.攻击速度 = 1.8f;
        dtgw.基础经验 = 800;
        dtgw.经验系数 = 60;
        dtgw.必掉材料 = "化龙角";

    }

}
