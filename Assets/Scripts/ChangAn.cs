using UnityEngine;
public class ChangAn : MonoBehaviour
{
    public float Ping;
    private bool IsStart = false;
    private float LastTime = 0;
    private 怪物属性 gwsx;
    private 人物属性 rwsx;
    private string 人物攻击目标;

    private void Start()
    {
        gwsx = gameObject.transform.parent.GetComponent<怪物属性>();
        rwsx = GameObject.Find("牧师").GetComponent<人物属性>();
    }
    void Update()
    {
        if (IsStart && Ping > 0 && LastTime > 0 && Time.time - LastTime > Ping)
        {
            //Debug.Log("长按触发");
            IsStart = false;
            LastTime = 0;
        }
    }
    public void LongPress(bool bStart)
    {
        IsStart = bStart;
        if (IsStart)
        {
            LastTime = Time.time;
           // Debug.Log("长按开始");
        }
        else if (LastTime != 0)
        {
            LastTime = 0;
            // Debug.Log("长按取消");
            //点击效果
            人物攻击目标=gwsx.开启战斗();
            rwsx.攻击目标名字 = 人物攻击目标;
            rwsx.开启战斗();
        }
    }
}
