using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class MakeMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NewPythonScript();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPythonScript()
    {
        PythonRunner.RunFile("Assets/new_python_script.py");
    }
}
