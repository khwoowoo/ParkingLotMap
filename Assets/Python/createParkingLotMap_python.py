import os
import sys
import numpy as np
import open3d as o3d
import threading
import glob

# 파일에 내용을 쓰는 함수
def write_to_file(file_path, text):
    with open(file_path, "a") as f:
        f.write(text)

# 포인트 클라우드 하나 프로세스
def process_point_cloud(input_path, output_path, lock):
    pcd = o3d.io.read_point_cloud(input_path)

    pcd.estimate_normals(search_param=o3d.geometry.KDTreeSearchParamHybrid(radius=0.1, max_nn=30))

    alpha = 1.9
    alpha_mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(pcd, alpha)
    alpha_mesh.compute_vertex_normals()

    o3d.io.write_triangle_mesh(output_path, alpha_mesh)

    pcd_filename=os.path.basename(input_path).split(".")[0]
    means = np.mean(np.asarray(pcd.points), axis=0)
    
    # txt 파일은 하나에 여러 쓰레드가 써야해서 락 필요
    with lock:
        write_to_file(txt_file_path, pcd_filename+" "+" ".join(map(str, means))+"\n")

# 배치 만들어서 파일 프로세스
def process_files_in_batch(batch):
    threads = []# 락 생성
    lock = threading.Lock()
    for file in batch:
        input_path = f"{pcd_folder_path}/{file}.pcd"
        output_path = f"{obj_folder_path}/{file}.obj"
        t = threading.Thread(target=process_point_cloud, args=(input_path, output_path, lock))
        threads.append(t)

    for t in threads:
        t.start()

    for t in threads:
        t.join()


# 입력 폴더 경로 설정
pcd_folder_path = "./PCDs" # 여기 pcd 파일들이 모여있는 폴더 경로로 설정!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
# 출력 폴더 경로 설정
obj_folder_path = "../Resources/models" # 여기 obj 파일들이 출력할 폴더 경로로 설정!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

# 위치 저장할 txt 파일 생성
txt_file_path = "../Resources/models/location.txt"

# 폴더 내부의 모든 .pcd 파일을 불러옵니다.
pcd_files = glob.glob(os.path.join(pcd_folder_path, "*.pcd"))

# 파일 이름만 추출합니다.
pcd_filenames = [os.path.basename(pcd_file).split(".")[0] for pcd_file in pcd_files]

# 파일 이름을 출력합니다.
for filename in pcd_filenames:
    print(filename)

# pcd_filenames = ['pillar0_0', 'pillar0_1','pillar0_2','pillar0_3','pillar0_4','pillar0_5','pillar0_6', 'pillar1_0', 'pillar1_1','pillar1_2','pillar1_3','pillar1_4','pillar1_5','pillar1_6', 'pillar2_0', 'pillar2_1','pillar2_2','pillar2_3','pillar2_4','pillar2_5','pillar2_6','pillar3_0']

# 순차적으로 처리
#for i in range(len(pcd_filenames)):
#    process_point_cloud('walls/'+pcd_filenames[i]+'.pcd', 'Resources/walls/'+ pcd_filenames[i]+'.obj')


# 병렬 처리를 위한 쓰레드 생성
N = 1  # 한 번에 처리할 파일 개수
batches = [pcd_filenames[i:i + N] for i in range(0, len(pcd_filenames), N)]

for batch in batches:
    process_files_in_batch(batch)