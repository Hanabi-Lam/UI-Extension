using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brent.UI
{
    /// <summary>
    /// 属性管理类
    /// </summary>
    public class Attrs : IEnumerable
    {
        private List<Attr> attrs;
        private Action OnAttrsChangedEvent; //属性改变的回调
        public Attrs()
        {
            attrs = new List<Attr>();
        }

        private Attr this[AttrPos pos]
        {
            get
            {
                if ((int)pos >= attrs.Count)
                {
                    throw new Exception(string.Format("不存在的属性位置:｛0｝", pos.ToString()));
                }
                return attrs[(int)pos];
            }
        }
        #region 属性操作
        public void IncreaseAttrAmount(AttrPos pos, int value)
        {

            this[pos].SetAttrAmount(this[pos].GetAttrAmount() + value);
            OnAttrsChangedEvent?.Invoke();
        }
        public void DecreaseAttrAmount(AttrPos pos, int value)
        {
            this[pos].SetAttrAmount(this[pos].GetAttrAmount() - value);
            OnAttrsChangedEvent?.Invoke();
        }
        public void SetAttrAmount(AttrPos pos, int value)
        {
            this[pos].SetAttrAmount(value);
            OnAttrsChangedEvent?.Invoke();
        }
        public int GetAttrAmount(AttrPos pos)
        {
            return this[pos].GetAttrAmount();
        }
        public int GetAttrMinValue(AttrPos pos)
        {
            return this[pos].ATTR_MIN;
        }
        public int GetAttrMaxValue(AttrPos pos)
        {
            return this[pos].ATTR_MAX;
        }
        public float GetAttrAmountNormalized(AttrPos pos)
        {
            return this[pos].GetAttrAmountNormalized();
        }
        public void Add(AttrPos pos, Attr attr)
        {
            attrs.Insert((int)pos, attr);
        }
        #endregion

        public IEnumerator GetEnumerator()
        {
            return attrs.GetEnumerator();
        }
        /// <summary>
        /// 注册属性变化的回调
        /// </summary>
        /// <param name="action"></param>
        public void Register(Action action)
        {
            OnAttrsChangedEvent += action;
        }
    }
    /// <summary>
    /// 属性的模版
    /// </summary>
    public  class Attr
    {
        public readonly int ATTR_MIN;
        public readonly int ATTR_MAX;
        private int attrAmount;
        public Attr(int orig,int min, int max)
        {
            if (min > max)
            {
                throw new Exception(string.Format("属性最小值最大值异常:｛0｝｛1｝",min,max));
            }
            this.ATTR_MIN = min;
            this.ATTR_MAX = max;
            SetAttrAmount(orig);
        }
        public int GetAttrAmount()
        {
            return attrAmount;
        }
        public void SetAttrAmount(int amount)
        {
            attrAmount = Mathf.Clamp(amount, ATTR_MIN, ATTR_MAX);
        }

       
        public float GetAttrAmountNormalized()
        {
           return (float)attrAmount / ATTR_MAX;
        }
    }
    /// <summary>
    /// 属性 对应雷达图的位置 从y轴正方向 顺时针
    /// </summary>
    public enum AttrPos
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
    }

}