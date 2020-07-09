using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 扣血显示 : MonoBehaviour
{
    public int 扣血=-1;
    public float 文本显示时间 = 0.5f;
    public float 文本移动时间 = 0.1f;
    private Text 扣血文本;
    private Vector3 目标位置;
    private Vector3 原位置;
    // Start is called before the first frame update
    void Start()
    {
        扣血文本 = gameObject.GetComponent<Text>();
        目标位置 = new Vector3(扣血文本.transform.position.x, 扣血文本.transform.position.y - 10, 扣血文本.transform.position.z);
        原位置 = gameObject.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(扣血文本.transform.position, 原位置, 20);
        if (扣血!=-1) {

            扣血文本.text = "- " + 扣血;
            文本显示时间 -= Time.fixedDeltaTime;
            if (文本显示时间 <= 0)
            {       
                transform.position = Vector3.MoveTowards(扣血文本.transform.position, 目标位置, 8);
               
                    扣血文本.text = "";
                    扣血 = -1;
              
                   
                文本移动时间 = 0.2f;
                文本显示时间 = 0.5f;
            }
        }
    }

}
