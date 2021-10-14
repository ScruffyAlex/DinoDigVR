using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshData
{
    public List<Vector3> verticies = new List<Vector3>();
    public List<int> triangles = new List<int>();
    public List<Vector2> uv = new List<Vector2>();

    public List<Vector3> colliderVerticies = new List<Vector3>();
    public List<int> colliderTriangles = new List<int>();

    public MeshData waterMesh;
    private bool isMainMesh = true;

    public MeshData(bool isMainMesh)
    {
        if (isMainMesh)
        {
            waterMesh = new MeshData(false);
        }
    }

    public void AddVertex(Vector3 vertex, bool vertexGeneratesCollider)
    {
        verticies.Add(vertex);
        if(vertexGeneratesCollider)
        {
            colliderVerticies.Add(vertex);
        }
    }

    public void AddQuadTriangles(bool quadGeneratesCollider)
    {
        triangles.Add(verticies.Count - 4);
        triangles.Add(verticies.Count - 3);
        triangles.Add(verticies.Count - 1);

        triangles.Add(verticies.Count - 4);
        triangles.Add(verticies.Count - 2);
        triangles.Add(verticies.Count - 1);


        if(quadGeneratesCollider)
        {
            colliderTriangles.Add(colliderVerticies.Count - 4);
            colliderTriangles.Add(colliderVerticies.Count - 3);
            colliderTriangles.Add(colliderVerticies.Count - 2);
            colliderTriangles.Add(colliderVerticies.Count - 4);
            colliderTriangles.Add(colliderVerticies.Count - 2);
            colliderTriangles.Add(colliderVerticies.Count - 1);
        }
    }

}
