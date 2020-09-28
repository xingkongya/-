using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Good_materials 
{
    private string G_name;
    //private int G_id;
    private int G_num;
    //private int All_num;
    public Good_materials(){}
    public Good_materials(string G_name, int G_num) 
    {
        this.G_name = G_name;
        this.G_num = G_num;
    }
    public string g_name
    {
        get { return G_name; }
        set { G_name = value; }
    }
   /* public int g_id
    {
        get { return G_id; }
        set { G_id = value; }
    }*/
    public int get_num
    {
        get { return G_num; }
        set { G_num = value; }
    }

    /*public int all_num
    {
        get { return All_num; }
        set { All_num = value; }
    }*/


}
