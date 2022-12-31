using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;


public static class FileHandler
{
    /*
    public static void SaveToJSON<T> (List<T> toSave, string filename)
    {
        Debug.Log (GetPath (filename));
        string content = JsonHelper.ToJson<T>(toSave.ToArray());
        WriteFile(GetPath (filename), content);
    }

    public static void SaveToJSON<T> (T ToSave, string filename)
    {
        string content = JsonUtility.ToJson (ToSave);
        WriteFile (GetPath(filename), content)

    }

    public void ReadFromJSON()
    {

    }

    private string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    private void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter (fileStream))
        {
            writer.Write(content);
        }

    }

    private string ReadFile()
    {
        return "";
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }*/
}

