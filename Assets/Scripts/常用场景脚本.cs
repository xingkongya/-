using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class 常用场景脚本 : MonoBehaviour
{
    private 怪物战斗 gwsx;
    private GameObject 经验框;
    private GameObject 物品框;
    public Vector3 offset;
    public Vector3 offset2;
    public bool 是否有开场剧情 = false;
    public string 开场剧情关键字;
    public string 开场剧情场景名;


    // Start is called before the first frame update
    void Start()
    {
        if (是否有开场剧情) {
            if (PlayerPrefs.GetInt(开场剧情关键字) == 0) {
                SceneManager.LoadScene(开场剧情场景名);
            }
        }
        经验框 = Resources.Load<GameObject>("Prefabs/经验框");
        物品框 = Resources.Load<GameObject>("Prefabs/物品框");

    }

    // Update is called once per frame
    void Update()
    {

    }




    public void 获取经验特效(string 经验) {
        GameObject temp = GameObject.Instantiate(经验框);
        //实例化生成为牧师对象的子物体
        temp.transform.SetParent(GameObject.Find("牧师").transform);
        //实例化坐标与缩放比例
        temp.transform.position = GameObject.Find("牧师").transform.position + offset;
        temp.transform.localScale = new Vector3(1f, 1f, 1);
        temp.GetComponent<Text>().text = 经验;
    }

    public void 获取物品特效(string 物品)
    {
        GameObject temp = GameObject.Instantiate(物品框);
        //实例化生成为牧师对象的子物体
        temp.transform.SetParent(GameObject.Find("画布").transform);
        //实例化坐标与缩放比例
        temp.transform.position = GameObject.Find("地图系统").transform.position + offset2;
        temp.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        temp.GetComponent<Text>().text = 物品;
    }

    public void 物品持久化(string 物品,int 数量) {
        //持久化对象
        Good_materials gd;
        GoodDataSave save = new GoodDataSave();
        //先读取json中物品的数据
        Dictionary<string,Good_materials> D_gd = save.Load();
        //无则新建
        gd = new Good_materials(物品, 数量);
        //有则修改
        if (D_gd!=null&&D_gd.ContainsKey(物品))
        {
            Good_materials temp = D_gd[物品];
            gd = new Good_materials(temp.g_name, temp.get_num + 数量);
        }
             


        save.Save(gd);

    }


    public bool 概率(int 分子,int 分母) {

        //因为random在同一时间内生成的随机数是相同的.所以不能简单的new
        Random 随机类 = new Random(Guid.NewGuid().GetHashCode());
        int 随机数 = 随机类.Next(1, 分母 + 1);
        if (1 <= 随机数 && 随机数 <= 分子)
            return true;
        else
            return false;

    }

}
