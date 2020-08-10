using UnityEngine;
using UnityEngine.UI;

public class ChangAn : MonoBehaviour
{
    public float Ping;
    private bool IsStart = false;
    private float LastTime = 0;
    private 怪物战斗 gwzd;
    private 人物战斗 rwzd;
    private string 人物攻击目标;

    private void Start()
    {
        gwzd = gameObject.transform.parent.GetComponent<怪物战斗>();
        rwzd = GameObject.Find("牧师").GetComponent<人物战斗>();
    }
    void Update()
    {
        if (IsStart && Ping > 0 && LastTime > 0 && Time.time - LastTime > Ping)
        {
            Debug.Log("长按触发");
            IsStart = false;
            LastTime = 0;
            //长按触发查看怪物属性
            人物攻击目标 = gwzd.返回怪物名();
            //显示文本框
            GameObject.Find(人物攻击目标).transform.Find("Text").gameObject.SetActive(true);
            Text 属性文本=GameObject.Find(人物攻击目标).transform.Find("Text").GetComponent<Text>();
            属性文本.text = "攻击力=" + gwzd.攻击力 + "\n" + "防御力=" + gwzd.防御力 + "\n生命值 = " + gwzd.血量 + "\n" + "攻击速度=" + gwzd.攻击速度;
            if (Input.touchCount == 0)
            {

                GameObject.Find(人物攻击目标).transform.Find("Text").gameObject.SetActive(false);
            }

        }
    }
    public void LongPress(bool bStart)
    {
        IsStart = bStart;
        if (IsStart)
        {
            LastTime = Time.time;
            //Debug.Log("长按开始");
        }
        else if (LastTime != 0)
        {
            LastTime = 0;
            // Debug.Log("长按取消");
            //点击效果
            人物攻击目标=gwzd.开启战斗();
            rwzd.攻击目标名字 = 人物攻击目标;
            rwzd.开启战斗();
        }
    }
}
