using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JSONExample : MonoBehaviour
{
    public List<MyObject> objects;
    [SerializeField] MyObject myobjecttest;

    void Start()
    {
        
    }

    public void addPointJSONExample()
    {
        myobjecttest.value ++;
    }

    public void jsonExampleSaveData()
    {
        string json = JsonConvert.SerializeObject(objects);
        File.WriteAllText("jsonExampleScorebord.json", json);
        Debug.Log("JSON Example save");
        Debug.Log(json);
    }
}

[System.Serializable]
public class MyObject
{
    public int value;
    public string name;
}