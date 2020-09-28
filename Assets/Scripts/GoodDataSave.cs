using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public class GoodList
{
    public Dictionary<string, Good_materials> dictionary = new Dictionary<string, Good_materials>();
}
public class GoodDataSave 
{

   
    // Start is called before the first frame update
    void Start()
    {
    }

    public GoodList goodList = new GoodList();
    /// <summary>
    /// 保存JSON数据到本地的方法
    /// </summary>
    public void Save(Good_materials gd)
    {
        //打包后Resources文件夹不能存储文件，如需打包后使用自行更换目录
        string filePath = Application.persistentDataPath + @"/GoodData.json";
        //Debug.Log(Application.persistentDataPath + @"/GoodData.json");

        goodList.dictionary = Load();
        if (!File.Exists(filePath))  //不存在就创建键值对 
            goodList.dictionary.Add(gd.g_name, gd);
        else if(goodList.dictionary!=null)  //若存在就更新值
            goodList.dictionary[gd.g_name] = gd;

        //找到当前路径
        FileInfo file = new FileInfo(filePath);
        //判断有没有文件，有则打开文件，，没有创建后打开文件
        StreamWriter sw = file.CreateText();
        //ToJson接口将你的列表类传进去，，并自动转换为string类型
        string json = JsonMapper.ToJson(goodList.dictionary);
        //将转换好的字符串存进文件，
        sw.WriteLine(json);
        //注意释放资源
        sw.Close();
        sw.Dispose();

       // AssetDatabase.Refresh();

    }
    /// <summary>
    /// 读取保存数据的方法
    /// </summary>
    public Dictionary<string,Good_materials> Load()
    {
        //调试用的  //Debug.Log(1);

        //TextAsset该类是用来读取配置文件的
        //TextAsset asset = Resources.Load("JsonPerson") as TextAsset;

        Dictionary<string, Good_materials> dc = new Dictionary<string, Good_materials>() ;
        StreamReader streamReader;
        string filePath = Application.persistentDataPath + @"/GoodData.json";
        if (!File.Exists(filePath))  
        {
            /*FileInfo file = new FileInfo(filePath);//不存在就创建文件
            file.CreateText();
            streamReader = file.OpenText();*/
            return dc;
        }
        else
            streamReader = new StreamReader(filePath);
        string str = streamReader.ReadToEnd();

        if (str.Equals(""))  //读不到就退出此方法
        {
            streamReader.Close();
            streamReader.Dispose();
            return dc;
        }
        Dictionary<string, Good_materials> jsdata3 = JsonMapper.ToObject<Dictionary<string, Good_materials>>(str);
        //在这里循环输出表示读到了数据，，即此数据可以使用了
        /*for (int i = 0; i < jsdata3.Count; i++)
        {
            Debug.Log(jsdata3[i]);
        }*/

        //使用foreach输出的话会以[键，值]，，，
        /*foreach (var item in jsdata3)
        {
            Debug.Log(item);
        }*/

        streamReader.Close();
        streamReader.Dispose();
        return jsdata3;

    }

}
