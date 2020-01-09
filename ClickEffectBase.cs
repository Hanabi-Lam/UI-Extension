using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Brent.UI
{
    public class ClickEffectBase : ButtonEffectBase
    {
        //多选模式
        public static bool IsMultipleChoiceMode { get; set; }
        protected static ClickEffectBase LastSelected { get; set; }
        //选中框只有在点击的时候才会出现 所以放在点击的基类中
        protected Image SelectBg;

        private Vector3 defaultPos;
        private Vector3 defaultSacle;
        private Vector3 defaultEuler;

        protected override void Start()
        {
            SelectBg = transform.Find("SelectBoxBg").GetComponent<Image>();
            var button = GetComponent<UIButton>();
            button.onClick.AddListener(Effect);
            defaultPos = transform.position;
            defaultSacle = transform.localScale;
            defaultEuler = transform.eulerAngles;
        }
        protected override void Effect()
        {
            transform.DOKill();
            ResetData();
        }
        private void ResetData()
        {
            transform.position = defaultPos;
            transform.localScale = defaultSacle;
            transform.eulerAngles = defaultEuler;
        }
        /// <summary>
        /// 提供默认的选中框的效果方法
        /// </summary>
        public virtual void ShowBox()
        {
            if (SelectBg != null)
            {
                SelectBg.transform.localScale = Vector3.one;
            }
        }
        public virtual void HideBox()
        {
            if (SelectBg != null)
            {
                SelectBg.transform.localScale = Vector3.zero;
            }
        }
    }
}
