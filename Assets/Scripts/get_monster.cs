using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_monster : MonoBehaviour
{

    private bool 是否需要刷新 = false;
    public float 怪物刷新时间 = 6;
    private 怪物战斗 gwzd;
    // Start is called before the first frame update
    void Start()
    {
        gwzd = gameObject.transform.GetChild(0).gameObject.GetComponent<怪物战斗>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (是否需要刷新)
        {
            怪物刷新时间 -= Time.deltaTime;
            if (怪物刷新时间 <= 0)
            {
                gwzd.初始化();
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                怪物刷新时间 = 6;
                是否需要刷新 = false;
            }
        }
    }


    public void 开始刷新 ()
    {
        是否需要刷新 = true;
    }
}
