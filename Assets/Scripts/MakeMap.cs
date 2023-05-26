using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Scripting.Python;
using System.IO;

public class MakeMap : MonoBehaviour
{
    public string filename;
    public bool isPythonRun;
    // Start is called before the first frame update
    void Start()
    {
        //if (isPythonRun)
        //    PythonScriptRun(filename);
        //string path = "Assets/Resources/pillars/";
        //StreamReader sr = new StreamReader(path + "location.txt");
        //while (sr.Peek() >= 0)
        //{
        //    string position = sr.ReadLine();
        //    string[] posSlit = position.Split(' ');
        //    GameObject objFile = Resources.Load<GameObject>("pillars/" + posSlit[0]);
        //    //GameObject obj = Instantiate(objFile, new Vector3(float.Parse(posSlit[1]), float.Parse(posSlit[2]), float.Parse(posSlit[3])), Quaternion.identity);
        //    GameObject obj = Instantiate(objFile, Vector3.zero, Quaternion.identity);
        //    obj.transform.parent = gameObject.transform;
        //}
        //sr.Close();
        //
        //transform.Rotate(new Vector3(-90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PythonScriptRun(string _filename)
    {
        //PythonRunner.RunFile("Assets/" + _filename);
    }
}