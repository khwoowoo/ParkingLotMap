import os
import sys
import numpy as np
import open3d as o3d
import UnityEngine


filename = os.path.abspath('Assets/wall.pcd') 
output_path = os.path.abspath('Assets/model.obj') 

UnityEngine.Debug.Log(filename)

pcd = o3d.io.read_point_cloud(filename)

pcd.estimate_normals(search_param=o3d.geometry.KDTreeSearchParamHybrid(radius=0.1, max_nn=30))

alpha = 1.9
alpha_mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(pcd, alpha)
alpha_mesh.compute_vertex_normals()

o3d.io.write_triangle_mesh(output_path, alpha_mesh)

UnityEngine.Debug.Log(output_path)