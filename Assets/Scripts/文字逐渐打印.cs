using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 文字逐渐打印 : MonoBehaviour
{
    public Text wenZiText;
    public string str = "";
    string s = "";
    public float 语速=0.05f;


    // Start is called before the first frame update
    void OnEnable()
    {
        playText();
    }
    public void playText() {
        StartCoroutine(showText(str.Length));
    }
    IEnumerator showText(int strLenght) {
        int i = 0;
        while (i<strLenght) {
            yield return new WaitForSeconds(语速);
            s += str[i].ToString();
            wenZiText.text = s;
            i += 1;
        }
        StopAllCoroutines();//结束携程
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        s = "";
        str = "";
    }

}
