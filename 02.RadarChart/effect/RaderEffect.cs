using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Brent.UI
{
    public class RaderEffect : MonoBehaviour
    {
        public bool isPlay;
        private Material mat;
        private Color color;
        private bool increase;
        void Start()
        {
            mat = GetComponent<RaderImage>().material;
            color = mat.color;
        }
        private void Update()
        {
            color.g += .3f * Time.deltaTime * ((increase) ? 1f : -1f);
            mat.color = color;
            if (color.g >= 1f)
            {
                increase = false;
            }

            if (color.g <= .9f)
            {
                increase = true;
            }
        }
    }
}