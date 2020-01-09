using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
namespace Brent.UI
{
    public class ConcreteClickEffect : ClickEffectBase
    {
        
        protected override void Effect()
        {
            base.Effect();
            this.ShowBox();
            if (!IsMultipleChoiceMode && LastSelected!=null)
            {
                LastSelected.HideBox();            
            }
            LastSelected = this;
            transform.DOPunchScale(new Vector3(0, -0.2f, 0), 0.4f, 12, 0.5f);
        }

    }
}
