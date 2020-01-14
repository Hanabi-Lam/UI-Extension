using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Brent.UI
{
    /// <summary>
    /// 按钮特效基类
    /// </summary>
    public abstract class ButtonEffectBase : MonoBehaviour
    {
        protected virtual void Start()
        {
        }
        protected abstract void Effect();
    }
}
