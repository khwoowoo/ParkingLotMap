using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DoubleSidedMesh : MonoBehaviour
{
    void Start()
    {
        // MeshFilter에서 Mesh를 가져옵니다
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        // Mesh의 vertices, normals, uv, 그리고 triangles를 가져옵니다
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        Vector2[] uv = mesh.uv;
        int[] triangles = mesh.triangles;

        // 새로운 vertices, normals, uv, 그리고 triangles를 만들어 기존의 것과 병합합니다
        Vector3[] newVertices = new Vector3[vertices.Length * 2];
        Vector3[] newNormals = new Vector3[normals.Length * 2];
        Vector2[] newUv = new Vector2[uv.Length * 2];
        int[] newTriangles = new int[triangles.Length * 2];
        int count = vertices.Length;

        // 기존의 vertices, normals, uv, 그리고 triangles를 복사합니다
        for (int i = 0; i < count; i++)
        {
            newVertices[i] = vertices[i];
            newNormals[i] = normals[i];
            newUv[i] = uv[i];
        }

        // 기존의 triangles를 복사합니다
        for (int i = 0; i < triangles.Length; i += 3)
        {
            newTriangles[i] = triangles[i];
            newTriangles[i + 1] = triangles[i + 1];
            newTriangles[i + 2] = triangles[i + 2];
        }

        // 복사한 vertices, normals, uv를 반전시킵니다
        for (int i = 0; i < count; i++)
        {
            newVertices[i + count] = vertices[i];
            newNormals[i + count] = -normals[i];
            newUv[i + count] = uv[i];
        }

        // 복사한 triangles를 반전시킵니다
        for (int i = 0; i < triangles.Length; i += 3)
        {
            newTriangles[i + count] = triangles[i + 2] + count;
            newTriangles[i + 1 + count] = triangles[i + 1] + count;
            newTriangles[i + 2 + count] = triangles[i] + count;
        }

        // 메시를 동적으로 설정하고 읽기/쓰기 권한을 활성화합니다
        mesh.MarkDynamic();
        mesh.vertices = newVertices;
        mesh.normals = newNormals;
        mesh.uv = newUv;
        mesh.triangles = newTriangles;

        // MeshCollider가 있는 경우 MeshCollider도 업데이트합니다
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            meshCollider.sharedMesh = mesh;
        }
    }
}