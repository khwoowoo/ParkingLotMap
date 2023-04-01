using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class MakeMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PythonScriptRun();
        GameObject game = Resources.Load<GameObject>("model_1.9");
        Instantiate(game, Vector3.zero, Quaternion.identity);
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
