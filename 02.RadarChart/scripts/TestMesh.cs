using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMesh : MonoBehaviour
{
    // Start is called before the first frame update
    private int attrCount = 5;
    private CanvasRenderer radarMeshCanvasRenderer;
    [SerializeField] private Material material;
    [SerializeField] private Texture2D texture;
    void Start()
    {
        radarMeshCanvasRenderer= transform.GetComponent<CanvasRenderer>();
        DrawRadar();
    }
    public void DrawRadar()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[3];

        int[] triangles = new int[3];


        vertices[0] = Vector3.zero;
        vertices[1] =new Vector3(0,100,0);
        vertices[2] = new Vector3(100, 100, 0);
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
    
        mesh.triangles = triangles;
        radarMeshCanvasRenderer.SetMesh(mesh);
        radarMeshCanvasRenderer.SetMaterial(material, texture);

    }
}
