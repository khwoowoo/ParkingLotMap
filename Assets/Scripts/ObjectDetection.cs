using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectDetection : MonoBehaviour
{
    public GameObject objPrefab;
    public float time = 0.5f;
    public string fileName;
    public float range;

    List<Object> objList;
    int subfileName;
    bool isStop;

    // Start is called before the first frame update
    void Start()
    {
        range = 1f;
        subfileName = 0;
        objList = new List<Object>();
        if (fileName != "static")
        {
            StartCoroutine("FindObject");
        }
        else
        {
            GetStaticObjectDetection();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetStaticObjectDetection()
    {
        try
        {
            string path = "Assets/final_center_points/staticpcd/original/";
            StreamReader sr = new StreamReader(path + "0.txt");
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            while (sr.Peek() >= 0)
            {
                string position = sr.ReadLine();
                string[] posSlit = position.Split(' ');
                GameObject obj = Instantiate(objPrefab, new Vector3(float.Parse(posSlit[0]), float.Parse(posSlit[1]), float.Parse(posSlit[2])) * range, Quaternion.identity);
                obj.transform.parent = gameObject.transform;
            }
            transform.eulerAngles = new Vector3(-90f, 0f, 0f);
            sr.Close();
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("failed");
        }
    }

    void GetObjectDetection()
    {
        if (isStop == true)
        {
            return;
        }

        if (objList.Count > 0)
        {
            foreach(GameObject i in objList)
            {
                Destroy(i);
            }
            objList.Clear();
        }

        try
        {
            string path = "Assets/final_center_points/" + fileName+"/";
            StreamReader sr = new StreamReader(path + subfileName.ToString() + ".txt");
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            while (sr.Peek() >= 0)
            {
                string position = sr.ReadLine();
                string[] posSlit = position.Split(' ');
                GameObject obj = Instantiate(objPrefab, new Vector3(float.Parse(posSlit[0]), float.Parse(posSlit[1]), float.Parse(posSlit[2])) * range, Quaternion.identity);
                obj.transform.parent = gameObject.transform;
                objList.Add(obj);
            }
            sr.Close();
            transform.eulerAngles = new Vector3(-90f, 0f, 0f);
            subfileName++;
        }
        catch (FileNotFoundException e)
        {
            // 예외 처리
            isStop = true;
            foreach (GameObject i in objList)
            {
                Destroy(i);
            }
            objList.Clear();
            Debug.Log("failed");
        }
    
    }

    IEnumerator FindObject()
    {
        while (!isStop)
        {
            yield return new WaitForSeconds(time);
            GetObjectDetection();
        }
    }

}
