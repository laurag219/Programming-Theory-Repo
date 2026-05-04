using UnityEngine;

// INHERITANCE
public class Triangle : Shape
{
    [SerializeField] private float sideLength = 1.2f;

    // POLYMORPHISM
    public override string DisplayText()
    {
        return $"{Name} color {ColorName} ";
    }

    private void Awake()
    {
        GenerateTriangleMesh();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnValidate()
    {
        if (Application.isPlaying) return;
        GenerateTriangleMesh();
    }

    private void GenerateTriangleMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = "TriangleMesh";

        float height = sideLength * Mathf.Sqrt(3) / 2f;
        float halfSide = sideLength / 2f;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 0, height * 0.666f),
            new Vector3(-halfSide, 0, -height * 0.333f),
            new Vector3(halfSide, 0, -height * 0.333f)
        };

        int[] triangles = new int[] { 0, 2, 1 };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
            normals[i] = Vector3.up;
        mesh.normals = normals;

        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null) mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = mesh;

        MeshRenderer mr = GetComponent<MeshRenderer>();
        if (mr == null) mr = gameObject.AddComponent<MeshRenderer>();

        MeshCollider mc = GetComponent<MeshCollider>();
        if (mc == null) mc = gameObject.AddComponent<MeshCollider>();
        mc.sharedMesh = mesh;

        if (mr.sharedMaterial == null)
        {
            Material mat = new Material(Shader.Find("Unlit/Color"));
            mat.color = Color.blue;
            mr.sharedMaterial = mat;
        }
    }
}