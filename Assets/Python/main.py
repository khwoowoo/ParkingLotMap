import os
import sys
import numpy as np
import open3d as o3d
#import UnityEngine
import math
import time

filename = os.path.abspath('./final_map.pcd') 
output_path = os.path.abspath('./final_map.obj') 

#UnityEngine.Debug.Log(filename)



start = time.time()

pcd = o3d.io.read_point_cloud(filename)
radii = [0.005, 0.01, 0.02, 0.04]
mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_ball_pivoting(pcd, o3d.utility.DoubleVector(radii))
o3d.io.write_triangle_mesh(output_path, mesh)

#pcd = o3d.io.read_point_cloud(filename)
#voxel_down_pcd = pcd.voxel_down_sample(voxel_size=0.1)
#mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(voxel_down_pcd, alpha=1)
#o3d.io.write_triangle_mesh(output_path, mesh)

end = time.time()

print(f"{end - start:.5f} sec")
o3d.visualization.draw_geometries(mesh, mesh_show_back_face=True)

#UnityEngine.Debug.Log(output_path)