import os
import sys
import numpy as np
import open3d as o3d
import UnityEngine

# 입출력 위치 설정
filename = os.path.abspath('Assets/wall.pcd') # ply 또는 pcd 등등 포인트 클라우드 파일의 위치로 변경!!!!!!!!
output_path = os.path.abspath('Assets/model.obj') # 출력 obj 위치로 변경!!!!!!!!!

# 유니티 디버그 로그
UnityEngine.Debug.Log(filename)

# 포인트 클라우드 읽기
pcd = o3d.io.read_point_cloud(filename)

# 법선(normal) 계산
pcd.estimate_normals(search_param=o3d.geometry.KDTreeSearchParamHybrid(radius=0.1, max_nn=30))

# alpha shapes로 메쉬 생성
alpha = 1.9
alpha_mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(pcd, alpha)
alpha_mesh.compute_vertex_normals()

# 부드럽게 필터링(필요시 아래 주석 해제)
# alpha_mesh =  alpha_mesh.filter_smooth_laplacian()

# 생성된 매쉬 출력
o3d.io.write_triangle_mesh(output_path, alpha_mesh)

# 유니티 디버그 로그
UnityEngine.Debug.Log(output_path)