using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Brent.UI
{
    /// <summary>
    /// 具体的长按提示
    /// </summary>
    public class ConcreteLongPressEffect : LongPressEffectBase
    {
        public float Duration = 0.3f;
        private Material tipBgMat;
        protected override void Start()
        {
            base.Start();
            tipBgMat = TipBg.material;
        }
        protected override void Effect()
        {
            base.Effect();
            PlayAnimation();
        }

        protected override void PlayAnimation()
        {
            tipBgMat.DOFloat(1, "_ProgressValue", Duration).OnComplete(() => TipBg.gameObject.SetActive(false));
        }
        protected override void ResetData()
        {
            tipBgMat.SetFloat("_ProgressValue", 0);
            Vector2 point = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(UIManager.Instance.PopUICanvas, point, UIManager.Instance.UICamera, out pos);
            TipBg.transform.localPosition = new Vector3(pos.x+30,pos.y+30,0);
            TipBg.gameObject.SetActive(true);
        }
    }


}