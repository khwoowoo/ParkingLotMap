using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;
using System.IO;

public class MakeMap : MonoBehaviour
{
    public GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        //PythonScriptRun();
        int count = 1;
        StreamReader sr = new StreamReader("model position.txt");
        while (sr.Peek() >= 0)
        {
            string position = sr.ReadLine();
            string[] posSlit = position.Split(' ');
            GameObject objFile = Resources.Load<GameObject>("model_"+ count++);
            GameObject obj = Instantiate(objFile, new Vector3(float.Parse(posSlit[0]), float.Parse(posSlit[1]), float.Parse(posSlit[2])), Quaternion.identity);
            obj.transform.parent = gameObject.transform;
        }
        sr.Close();

        transform.Rotate(new Vector3(90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PythonScriptRun()
    {
        PythonRunner.RunFile("Assets/new_python_script.py");
    }
}
