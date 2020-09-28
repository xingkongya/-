using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Good_equipment : MonoBehaviour
{
    private string 装备名;
    private string 位置;
    private string 品质;
    private int 加攻;
    private int 加防;
    private int 加血;
    private float 加攻速;
    private int 套装id;
    private int 数量;
    private int 卖价;
    
    public Good_equipment() { }
    public Good_equipment(string 装备名, int 数量,string 位置,string 品质, int 加攻, int 加防,int 加血,float 加攻速,int 套装id, int 卖价)
    {
        this.装备名 = 装备名;
        this.数量 = 数量;
        this.位置 = 位置;
        this.品质 = 品质;
        this.加攻 = 加攻;
        this.加防 = 加防;
        this.加血 = 加血;
        this.加攻速 = 加攻速;
        this.套装id = 套装id;
        this.卖价 = 卖价;
    }
    public string get_name
    {
        get { return 装备名; }
        set { 装备名 = value; }
    }
    /* public int g_id
     {
         get { return G_id; }
         set { G_id = value; }
     }*/
    public int get_num
    {
        get { return 数量; }
        set { 数量 = value; }
    }

    /*public int all_num
    {
        get { return All_num; }
        set { All_num = value; }
    }*/

    public int get_攻击
    {
        get { return 加攻; }
        set { 加攻 = value; }
    }
    public int get_防御
    {
        get { return 加防; }
        set { 加防 = value; }
    }
    public int get_血量
    {
        get { return 加血; }
        set { 加血 = value; }
    }
    public float get_攻速
    {
        get { return 加攻速; }
        set { 加攻速 = value; }
    }
    public int get_卖价
    {
        get { return 卖价; }
        set { 卖价 = value; }
    }
    public string get_位置
    {
        get { return 位置; }
        set { 位置 = value; }
    }
    public string get_品质
    {
        get { return 品质; }
        set { 品质 = value; }
    }
}
