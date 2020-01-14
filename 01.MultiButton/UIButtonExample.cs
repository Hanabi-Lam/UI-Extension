using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brent.UI;
using UnityEngine.UI;

public class UIButtonExample : MonoBehaviour
{
    // Start is called before the first frame update
    public UIButton button1;
    public UIButton button2;
    void Start()
    {

        //button1 = GetComponent<UIButton>();
        button1.onClick.AddListener(() => Debug.Log("1单击"));
        button1.onDoubleClick.AddListener(() => Debug.Log("1双击击"));
        button1.onEnterPress.AddListener(() => Debug.Log("1进入长按"));
        button1.onPress.AddListener(() => Debug.Log("1长按中"));
        button1.onExitPress.AddListener(() => Debug.Log("1长按退出"));

        //button2 = GetComponent<UIButton>();
        button2.onClick.AddListener(() => Debug.Log("2单击"));
        button2.onDoubleClick.AddListener(() => Debug.Log("2双击击"));
        button2.onEnterPress.AddListener(() => Debug.Log("2进入长按"));
        button2.onPress.AddListener(() => Debug.Log("2长按中"));
        button2.onExitPress.AddListener(() => Debug.Log("2长按退出"));


    }

    // Update is called once per frame
    void Update()
    {

    }
}
