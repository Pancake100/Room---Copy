using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CreateRingMesh : MonoBehaviour
{
    public float innerRadius = 0.2f;
    public float outerRadius = 0.4f;
    public int segments = 64;

    void Awake()
    {
        Mesh ringMesh = GenerateRingMesh(innerRadius, outerRadius, segments);
        GetComponent<MeshFilter>().mesh = ringMesh;
    }

    Mesh GenerateRingMesh(float inner, float outer, int seg)
    {
        Mesh mesh = new Mesh();
        mesh.name = "RingMesh";

        Vector3[] vertices = new Vector3[seg * 2];
        int[] triangles = new int[seg * 6];
        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i < seg; i++)
        {
            float angle = 2 * Mathf.PI * i / seg;
            float cos = Mathf.Cos(angle);
            float sin = Mathf.Sin(angle);

            vertices[i * 2] = new Vector3(cos * inner, sin * inner, 0);
            vertices[i * 2 + 1] = new Vector3(cos * outer, sin * outer, 0);

            uvs[i * 2] = new Vector2(0.5f + cos * inner * 0.5f, 0.5f + sin * inner * 0.5f);
            uvs[i * 2 + 1] = new Vector2(0.5f + cos * outer * 0.5f, 0.5f + sin * outer * 0.5f);
        }

        for (int i = 0; i < seg; i++)
        {
            int i0 = i * 2;
            int i1 = i * 2 + 1;
            int i2 = (i * 2 + 2) % (seg * 2);
            int i3 = (i * 2 + 3) % (seg * 2);

            int t = i * 6;
            triangles[t] = i0;
            triangles[t + 1] = i2;
            triangles[t + 2] = i1;
            triangles[t + 3] = i1;
            triangles[t + 4] = i2;
            triangles[t + 5] = i3;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        return mesh;
    }
}



