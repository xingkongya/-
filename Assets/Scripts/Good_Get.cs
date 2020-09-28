using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Good_Get : MonoBehaviour
{
    public float 经验销毁时间=0.8f;
    public float 物品销毁时间=1f;
    public int 经验移动速度 = 50;
    public int 物品移动速度 = 100;

    // Use this for initialization
    void Start()
    {
        if(gameObject.tag.Equals("经验框"))
            //0.8秒后销毁
            Destroy(this.gameObject, 经验销毁时间);
        else
            //1秒后销毁
            Destroy(this.gameObject, 物品销毁时间);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("经验框"))
            //移动效果
            transform.Translate(Vector3.up * Time.deltaTime * 经验移动速度);
        else
            transform.Translate(Vector3.up * Time.deltaTime * 物品移动速度);
    }

}
