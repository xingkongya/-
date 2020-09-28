using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beibao_materials : MonoBehaviour
{
    private GameObject 物品栏预制体;
    private GameObject Content;
    GoodDataSave save = new GoodDataSave();

    void OnEnable()
    {
        清除数据();
        刷新页面();
    }

    private void Start()
    {
        清除数据();
        刷新页面();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void 刷新页面() {
        物品栏预制体 = Resources.Load<GameObject>("Prefabs/背包物品栏预制体") as GameObject;
        Content = gameObject.transform.Find("Scroll View/Viewport/Content").gameObject;
        Dictionary<string,Good_materials> D_g= save.Load();
        //使用foreach输出的话会以[键，值]，，，
        int i = 0;
        foreach (var item in D_g)
        {
            GameObject pb = GameObject.Instantiate(物品栏预制体) as GameObject;
            pb.transform.SetParent(Content.transform);  //设置为 Content 的子对象
            Transform 定位 = GameObject.Find("定位").gameObject.transform;
            if (i == 0)                 
                pb.transform.localPosition = 定位.localPosition;
            else
                pb.transform.localPosition = new Vector3(定位.localPosition.x, 定位.localPosition.y-100*i, 定位.localPosition.z);
            i++;
            pb.transform.localScale = new Vector3(1,1,1);
            pb.transform.Find("物品名").GetComponent<Text>().text = item.Value.g_name;
            pb.transform.Find("数量").GetComponent<Text>().text = item.Value.get_num+"";
        }
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, D_g.Count*100);

    }

  

    void 清除数据() {
        // Content = gameObject.transform.Find("Scroll View/Viewport/Content").gameObject;
        GameObject[] 物品栏们 = GameObject.FindGameObjectsWithTag("物品栏");
        for (int i=0;i<物品栏们.Length;i++) {
            Destroy(物品栏们[i]);
        }

    }
}
