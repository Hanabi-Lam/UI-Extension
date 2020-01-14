using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brent.UI;
using UnityEngine.UI;
/// <summary>
/// Example 玩家属性 
/// 使用流程拼好UI，在空白的GameObject上挂载CanvasRenderer &RadarImage 
/// AttrData中加入 雷达图的属性枚举  扩充AttrPos支持多角的雷达图 
/// 写一个类型下面的一个脚本 
/// </summary>
public class PlayerAttrRaderCtrl : MonoBehaviour
{
    [SerializeField] private RaderImage raderImg;

    private Attrs palyerRader;
    void Start()
    {
        int attrCount = Enum.GetValues(typeof(PlayerAttrName)).Length;
        palyerRader = new Attrs()
         {
            { (AttrPos)PlayerAttrName.Attack,  new Attr(5,0,10)},
            { (AttrPos)PlayerAttrName.Defence, new Attr(6,0,10)},
            { (AttrPos)PlayerAttrName.Speed,   new Attr(7,0,10)},
            { (AttrPos)PlayerAttrName.Mana,    new Attr(8,0,10)},
            { (AttrPos)PlayerAttrName.Health,  new Attr(10,0,10)},
         };
        palyerRader.Register(UpdateText);
        raderImg.SetAttrCount(attrCount);
        raderImg.SetAttrs(palyerRader);
        InitView();
        UpdateText();
    }
    private void InitView()
    {
        var btnRoot = transform.Find("BtnGroup");
        btnRoot.Find("attackAddBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.IncreaseAttrAmount((AttrPos)PlayerAttrName.Attack, 1));
        btnRoot.Find("attackSubBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.DecreaseAttrAmount((AttrPos)PlayerAttrName.Attack, 1));

        btnRoot.Find("defenceAddBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.IncreaseAttrAmount((AttrPos)PlayerAttrName.Defence, 1));
        btnRoot.Find("defenceSubBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.DecreaseAttrAmount((AttrPos)PlayerAttrName.Defence, 1));

        btnRoot.Find("speedAddBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.IncreaseAttrAmount((AttrPos)PlayerAttrName.Speed, 1));
        btnRoot.Find("speedSubBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.DecreaseAttrAmount((AttrPos)PlayerAttrName.Speed, 1));

        btnRoot.Find("manaAddBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.IncreaseAttrAmount((AttrPos)PlayerAttrName.Mana, 1));
        btnRoot.Find("manaSubBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.DecreaseAttrAmount((AttrPos)PlayerAttrName.Mana, 1));

        btnRoot.Find("healthAddBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.IncreaseAttrAmount((AttrPos)PlayerAttrName.Health, 1));
        btnRoot.Find("healthSubBtn/Button").GetComponent<Button>().onClick.AddListener(() => palyerRader.DecreaseAttrAmount((AttrPos)PlayerAttrName.Health, 1));

        transform.Find("ramdomBtn").GetComponent<Button>().onClick.AddListener(RandomAttr);
    }

    private void UpdateText()
    {
        transform.Find("Text").GetComponent<Text>().text =
            "ATTACK: " + palyerRader.GetAttrAmount((AttrPos)PlayerAttrName.Attack) + "\n" +
            "DEFENCE: " + palyerRader.GetAttrAmount((AttrPos)PlayerAttrName.Defence) + "\n" +
            "SPEED: " + palyerRader.GetAttrAmount((AttrPos)PlayerAttrName.Speed) + "\n" +
            "MANA: " + palyerRader.GetAttrAmount((AttrPos)PlayerAttrName.Mana) + "\n" +
            "HEALTH: " + palyerRader.GetAttrAmount((AttrPos)PlayerAttrName.Health);
    }
    private void RandomAttr()
    {
        int attrCount = Enum.GetValues(typeof(PlayerAttrName)).Length;
        for (int i = 0; i < attrCount; i++)
        {
            int val = UnityEngine.Random.Range(palyerRader.GetAttrMinValue((AttrPos)i), palyerRader.GetAttrMaxValue((AttrPos)i));
            palyerRader.SetAttrAmount((AttrPos)i, val);
        }

    }
    //bool anim;
    //FunctionPeriodic.Create(() => {
    //        if (anim) {
    //            if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Attack); else stats.DecreaseStatAmount(Stats.Type.Attack);
    //            if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Defence); else stats.DecreaseStatAmount(Stats.Type.Defence);
    //            if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Speed); else stats.DecreaseStatAmount(Stats.Type.Speed);
    //            if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Mana); else stats.DecreaseStatAmount(Stats.Type.Mana);
    //            if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Health); else stats.DecreaseStatAmount(Stats.Type.Health);
    //        }
    //    }, .1f);
}
