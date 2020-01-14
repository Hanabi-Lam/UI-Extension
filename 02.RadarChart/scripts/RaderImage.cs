using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Brent.UI {

    /// <summary>
    /// 雷达图
    /// </summary>
    public class RaderImage : MonoBehaviour
    {
        private int attrCount;
        private float halfWidth;
        private CanvasRenderer radarMeshCanvasRenderer;
  
        [SerializeField] private Texture2D texture;
        public Material material;
        public Attrs attrs;
        private void Awake()
        {
            halfWidth = transform.GetComponent<RectTransform>().rect.width / 2;
            radarMeshCanvasRenderer = transform.GetComponent<CanvasRenderer>();
        }
        /// <summary>
        /// 核心 绘制雷达图的五角区域
        /// </summary>
        private void DrawRadar()
        {   
            Mesh mesh = new Mesh();
            Vector3[] vertices = new Vector3[attrCount + 1];
            Vector2[] uv = new Vector2[attrCount + 1];  //网格uv指的是三角形边的绘制方式 通过设置点
            int[] triangles = new int[attrCount * 3]; //三角形的数量  决定绘制的顺序

            float angleIncrement = 360f / attrCount;

            vertices[0] = Vector3.zero;  //圆点 类似画圆
            uv[0] = Vector2.zero;

            for (int i = 1; i < vertices.Length; i++)
            {
                vertices[i] = Quaternion.Euler(0, 0, -angleIncrement * (i-1)) * Vector3.up * halfWidth * attrs.GetAttrAmountNormalized((AttrPos)(i - 1));//旋转后的顶点坐标
            }
            for (int i = 1; i < uv.Length; i++)//设置uv
            {
                uv[i] = Vector2.one;
            }
            for (int i = 0; i < attrCount; i++)//设置绘制三角顺序
            {
                triangles[i* 3] = 0;
                triangles[i* 3 + 1] = i + 1;
                if (i == attrCount - 1)
                {
                    triangles[i * 3 + 2] = 1;
                }
                else {
                    triangles[i * 3 + 2] = i + 2;
                }
            }
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;

            radarMeshCanvasRenderer.SetMesh(mesh);
            radarMeshCanvasRenderer.SetMaterial(material, texture);

        }
        /// <summary>
        /// 设置雷达图的属性数量 也就是三角形数量 
        /// </summary>
        public void SetAttrCount(int count)
        {
            attrCount = count;
        }
        public void SetAttrs(Attrs attrs)
        {
            this.attrs = attrs;
            attrs.Register(DrawRadar);
            DrawRadar();
        }
    }
}