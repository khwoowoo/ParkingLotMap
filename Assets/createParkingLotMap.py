import os
import sys
import numpy as np
import open3d as o3d
import UnityEngine
import threading

def process_point_cloud(input_path, output_path):
    UnityEngine.Debug.Log('input Log: '+ input_path)

    pcd = o3d.io.read_point_cloud(input_path)

    pcd.estimate_normals(search_param=o3d.geometry.KDTreeSearchParamHybrid(radius=0.1, max_nn=30))

    alpha = 1.9
    alpha_mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(pcd, alpha)
    alpha_mesh.compute_vertex_normals()

    o3d.io.write_triangle_mesh(output_path, alpha_mesh)

    UnityEngine.Debug.Log('output Log: '+ output_path)

# 입력 파일 및 출력 파일 경로 설정
fileanames = ['pillar0_0', 'pillar0_1','pillar0_2','pillar0_3','pillar0_4','pillar0_5','pillar0_6', 'pillar1_0', 'pillar1_1','pillar1_2','pillar1_3','pillar1_4','pillar1_5','pillar1_6', 'pillar2_0', 'pillar2_1','pillar2_2','pillar2_3','pillar2_4','pillar2_5','pillar2_6','pillar3_0']

#for i in range(len(fileanames)):
#    process_point_cloud('Assets/pillars/'+fileanames[i]+'.pcd', 'Assets/Resources/pillars/'+ fileanames[i]+'.obj')
#
# 병렬 처리를 위한 쓰레드 생성
threads = []
for i in range(len(fileanames)):
    t = threading.Thread(target=process_point_cloud, args=('Assets/pillars/'+fileanames[i]+'.pcd', 'Assets/Resources/pillars/'+ fileanames[i]+'.obj'))
    threads.append(t)

# 쓰레드 시작
for t in threads:
    t.start()

# 모든 쓰레드가 완료될 때까지 대기
for t in threads:
    t.join()

#import os
#import sys
#import numpy as np
#import open3d as o3d
#import UnityEngine
#import threading
#
#def process_point_cloud(input_path, output_path):
#    UnityEngine.Debug.Log('input Log: '+ input_path)
#
#    pcd = o3d.io.read_point_cloud(input_path)
#
#    pcd.estimate_normals(search_param=o3d.geometry.KDTreeSearchParamHybrid(radius=0.1, max_nn=30))
#
#    alpha = 1.9
#    alpha_mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(pcd, alpha)
#    alpha_mesh.compute_vertex_normals()
#
#    o3d.io.write_triangle_mesh(output_path, alpha_mesh)
#
#    UnityEngine.Debug.Log('output Log: '+ output_path)
#
#def process_files_in_batches(batch_size):
#    for i in range(0, len(fileanames), batch_size):
#        threads = []
#
#        for j in range(i, min(i + batch_size, len(fileanames))):
#            t = threading.Thread(target=process_point_cloud, args=('Assets/pillars/'+fileanames[i]+'.pcd', 'Assets/Resources/pillars/'+ fileanames[i]+'.obj'))
#            threads.append(t)
#
#        # 쓰레드 시작
#        for t in threads:
#            t.start()
#
#        # 모든 쓰레드가 완료될 때까지 대기
#        for t in threads:
#            t.join()
#
## 입력 파일 및 출력 파일 경로 설정
#fileanames = ['pillar0_0', 'pillar0_1','pillar0_2','pillar0_3','pillar0_4','pillar0_5','pillar0_6', 'pillar1_0', 'pillar1_1','pillar1_2','pillar1_3','pillar1_4','pillar1_5','pillar1_6', 'pillar2_0', 'pillar2_1','pillar2_2','pillar2_3','pillar2_4','pillar2_5','pillar2_6','pillar3_0']
#
## 배치 크기 설정 (한 번에 처리할 작업 수)
#batch_size = 3
#
## 파일을 배치로 처리
#process_files_in_batches(batch_size)
