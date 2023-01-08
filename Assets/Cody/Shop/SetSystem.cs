using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSystem : MonoBehaviour
{
public setSave setsave = new setSave();
[SerializeField] GameObject Player1;
[SerializeField] GameObject Player2;
[SerializeField] GameObject Player3;

void Awake()
{
    setLoadFromJson();
    
    Scene scene = SceneManager.GetActiveScene();
    if (scene.name == "runnerv2" && setsave.setItem1 == true)
    {
        Instantiate(Player1);
        Debug.Log("Player1");
    }else if (scene.name == "runnerv2" && setsave.setItem2 == true)
    {
        Instantiate(Player2);
    }else if (scene.name == "runnerv2" && setsave.setItem3 == true)
    {
        Instantiate(Player3);
    }else if (scene.name =="runnerv2")
    {
        Instantiate(Player1);
    }
}
public void setSaveToJson()
{     
    string setData = JsonUtility.ToJson(setsave);
    string filePath = Application.persistentDataPath + "/SetSave.json";
    Debug.Log(filePath);
    System.IO.File.WriteAllText(filePath, setData);
    Debug.Log("Save Sukces");
}

public void setLoadFromJson()
{
    string filePath = Application.persistentDataPath + "/SetSave.json";
    string setData = System.IO.File.ReadAllText(filePath);

    setsave = JsonUtility.FromJson<setSave>(setData);
    Debug.Log("Sukces Load set Data");
}

public void setItem1()
{
    setsave.setItem1 = true;
    setsave.setItem2 = false;
    setsave.setItem3 = false;
}

public void setItem2()
{
    setsave.setItem1 = false;
    setsave.setItem2 = true;
    setsave.setItem3 = false;
}

public void setItem3()
{
    setsave.setItem1 = false;
    setsave.setItem2 = false;
    setsave.setItem3 = true;
}

}

[System.Serializable]
public class setSave
{
    public bool setItem1;
    public bool setItem2;
    public bool setItem3;

}
