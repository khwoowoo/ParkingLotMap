using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DoubleSidedMesh : MonoBehaviour
{
    void Start()
    {
        // MeshFilter���� Mesh�� �����ɴϴ�
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        // Mesh�� vertices, normals, uv, �׸��� triangles�� �����ɴϴ�
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        Vector2[] uv = mesh.uv;
        int[] triangles = mesh.triangles;

        // ���ο� vertices, normals, uv, �׸��� triangles�� ����� ������ �Ͱ� �����մϴ�
        Vector3[] newVertices = new Vector3[vertices.Length * 2];
        Vector3[] newNormals = new Vector3[normals.Length * 2];
        Vector2[] newUv = new Vector2[uv.Length * 2];
        int[] newTriangles = new int[triangles.Length * 2];
        int count = vertices.Length;

        // ������ vertices, normals, uv, �׸��� triangles�� �����մϴ�
        for (int i = 0; i < count; i++)
        {
            newVertices[i] = vertices[i];
            newNormals[i] = normals[i];
            newUv[i] = uv[i];
        }

        // ������ triangles�� �����մϴ�
        for (int i = 0; i < triangles.Length; i += 3)
        {
            newTriangles[i] = triangles[i];
            newTriangles[i + 1] = triangles[i + 1];
            newTriangles[i + 2] = triangles[i + 2];
        }

        // ������ vertices, normals, uv�� ������ŵ�ϴ�
        for (int i = 0; i < count; i++)
        {
            newVertices[i + count] = vertices[i];
            newNormals[i + count] = -normals[i];
            newUv[i + count] = uv[i];
        }

        // ������ triangles�� ������ŵ�ϴ�
        for (int i = 0; i < triangles.Length; i += 3)
        {
            newTriangles[i + count] = triangles[i + 2] + count;
            newTriangles[i + 1 + count] = triangles[i + 1] + count;
            newTriangles[i + 2 + count] = triangles[i] + count;
        }

        // �޽ø� �������� �����ϰ� �б�/���� ������ Ȱ��ȭ�մϴ�
        mesh.MarkDynamic();
        mesh.vertices = newVertices;
        mesh.normals = newNormals;
        mesh.uv = newUv;
        mesh.triangles = newTriangles;

        // MeshCollider�� �ִ� ��� MeshCollider�� ������Ʈ�մϴ�
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            meshCollider.sharedMesh = mesh;
        }
    }
}