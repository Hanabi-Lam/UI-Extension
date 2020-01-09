using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Brent.UI
{
    /// TODO
    /// 选中框 按下的时候隐藏 抬起的时候显示
    /// 长按提示按钮 长按触发是播放一个短暂的Tween动画

    /// <summary>
    /// 适用与多种点击输入的按钮
    /// </summary>
    public class UIButton : Button, IDragHandler
    {   
        public ButtonClickEnum buttonClickEnum = ButtonClickEnum.All ;
        public int itemId = 0;                          //按钮对应显示的物品id

        public int clickThreshold = 500;
        public int doubleClickThreshold = 300;
        public float pressThreshold = 0.5f;             //触发长按的时间

        public ButtonClickedEvent onEnterPress;         //进入长按的事件
        public ButtonClickedEvent onExitPress;          //退出长按的事件
        public ButtonClickedEvent onDoubleClick;        //双击的事件
      

        private DateTime firstTime;                     //双击 记录第一次点击时间
        private DateTime secondTime;                    //双击 记录第二次点击时间
        private DateTime lastTime = default;            //上一次点击的时间 每一次抬起都去记录

        private bool isPointerDown = false;
        private bool longPressTriggered = false;
        private float timePressStarted;                 //按钮开始点击的时间

        private RectTransform rect;

        protected override void Start()
        {
            base.Start();
            rect = GetComponent<RectTransform>();
        }
        public override void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable)
            {
                return;
            }

            base.OnPointerDown(eventData);

            timePressStarted = Time.time;
            isPointerDown = true;
            longPressTriggered = false;


            if (firstTime.Equals(default))
            {
                firstTime = DateTime.Now;
            }
            else
            {
                secondTime = DateTime.Now;
            }

        }
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (!interactable)
            {
                return;
            }
            base.OnPointerUp(eventData);
            if (buttonClickEnum.HasFlag(ButtonClickEnum.Double))
            {
                DoubleMonitor();
            }
            isPointerDown = false;

        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (!interactable)
            {
                return;
            }
            if (buttonClickEnum.HasFlag(ButtonClickEnum.Single))
            {
                ClickMonitor();
                lastTime = DateTime.Now;
            }
        }
        private void Update()
        {
            if (buttonClickEnum.HasFlag(ButtonClickEnum.LongPress))
            {
                LongPressMonitor();
            }

        }
        private void ClickMonitor()
        {
            if (lastTime.Equals(default))
            {
                onClick?.Invoke();
            }
            else
            {
                var intervalTime = DateTime.Now - lastTime;
                float milliSeconds = intervalTime.Seconds * 1000 + intervalTime.Milliseconds;
                if (milliSeconds > clickThreshold)
                {
                    onClick?.Invoke();
                }
            }

        }
        private void DoubleMonitor()
        {
            if (!firstTime.Equals(default) && !secondTime.Equals(default))
            {
                var intervalTime = secondTime - firstTime;
                float milliSeconds = intervalTime.Seconds * 1000 + intervalTime.Milliseconds;
                //print(milliSeconds);       
                if (milliSeconds < doubleClickThreshold)
                {
                    DoubleClick();
                }
                UpdateTime();
            }
        }

        private void LongPressMonitor()
        {
            if (isPointerDown && !longPressTriggered)
            {
                if (Time.time - timePressStarted > pressThreshold)
                {
                    longPressTriggered = true;
                    onEnterPress?.Invoke();
                }
            }
            if (!isPointerDown && longPressTriggered)
            {
                onExitPress?.Invoke();
                longPressTriggered = false;
                ResetTime();
            }
        }
        /// <summary>
        /// 单击的封装
        /// </summary>
        private void SingleClick()
        {
            onClick?.Invoke();
            ResetTime();
        }
        /// <summary>
        /// 双击的封装
        /// </summary>
        private void DoubleClick()
        {
            onDoubleClick?.Invoke();
        }
        /// <summary>
        /// 重置按钮事件  
        /// 每一个事件触发后都要去重置一下 
        /// </summary>
        private void ResetTime()
        {
            firstTime = default;
            secondTime = default;
        }
        private void UpdateTime()
        {
            firstTime = secondTime;
            secondTime = default;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rect.anchoredPosition += eventData.delta;
        }

        [System.Flags]
        public enum ButtonClickEnum
        {
            None =0,
            Single = 1 << 1,
            Double = 1 << 2,
            LongPress = 1 << 3,
            All = Single | Double | LongPress
        }
    }
}