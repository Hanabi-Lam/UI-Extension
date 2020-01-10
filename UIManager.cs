using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 这部分归属UIFramework 后期写UI框架的时候会重写
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform uIroot;
    [SerializeField] private RectTransform commonCanvas;
    [SerializeField] private RectTransform popUICanvas;

    [SerializeField] private Camera uICamera;
    ///粗糙的单例 不是重点
    private static UIManager mInstance;
    public static UIManager Instance
    {
        get
        {
            if(mInstance ==null)
            {
                mInstance = FindObjectOfType<UIManager>();
            }
            return mInstance;
        }
    }

    public Transform UIRoot => uIroot;
    public RectTransform CommonCanvas => commonCanvas;
    public RectTransform PopUICanvas => popUICanvas;
    public Camera UICamera => uICamera;
}
