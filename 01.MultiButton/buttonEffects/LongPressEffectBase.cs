using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Brent.UI
{   
    /// <summary>
    /// 长按的提示 一般就是图片动画  
    /// </summary>
    public abstract class LongPressEffectBase : ButtonEffectBase
    {
        //长按提示的图片
        public Image TipBg;

        protected override void Start()
        {
            //TipBg = transform.Find("TipBg").GetComponent<Image>();
            var button = GetComponent<UIButton>();
            button.onEnterPress.AddListener(Effect);
        }
        protected override void Effect()
        {
            transform.DOKill();
            ResetData();
        }

        protected virtual void PlayAnimation()
        {

        }
        protected virtual void ResetData()
        {
            
        }
    }
}
