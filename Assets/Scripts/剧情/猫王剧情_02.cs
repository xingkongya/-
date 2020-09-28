using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 猫王剧情_02 : MonoBehaviour
{
    int num = 0;

    public void 单击显示剧情()
    {
      
            if (num >= 8)
            {
                SceneManager.LoadScene("mao_Home");
                return;
            }
                    //用Find损耗性能,有待优化
                    GameObject.Find(num + "_").transform.Find(num + "").gameObject.SetActive(true);
                    num++;
            
    }

    public void 场景跳转() {
        SceneManager.LoadScene("猫王剧情_03");
        return;
    }
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
       
    }
}
