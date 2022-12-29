using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZarzadzanieUI : MonoBehaviour
{
    public TextMeshProUGUI punktyWGrzeTekst;
    public TextMeshProUGUI punktyEkranKonca;
    public float punkty;
    public pointsSave pointssave = new pointsSave();

    [SerializeField] private AudioSource punktSoundEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //pointsLoadFromJson();
    }

    // Update is called once per frame
    void Update()
    {
        pointssave.name = "Test" +" " + pointssave.points;
    }

    public void DodajPunkt()
    {
        punkty++;
        punktyWGrzeTekst.text = punkty.ToString();
        punktyEkranKonca.text = punkty.ToString();
        punktSoundEffect.Play();
        pointssave.points++;
        
    }

    public void pointsSaveToJson()
    {     
    pointssave.logFromGame.Add(pointssave.name);
    string pointsData = JsonUtility.ToJson(pointssave);
    string filePath = Application.persistentDataPath + "/PointsSave.json";
    Debug.Log(filePath);
    System.IO.File.WriteAllText(filePath, pointsData);
    Debug.Log("Save Sukces");
    }

    public void pointsLoadFromJson()
    {
    string filePath = Application.persistentDataPath + "/PointsSave.json";
    string pointsData = System.IO.File.ReadAllText(filePath);

    pointssave = JsonUtility.FromJson<pointsSave>(pointsData);
    Debug.Log("Sukces Load Points Data");
    }


}

[System.Serializable]
public class pointsSave
{
    public List<string> logFromGame = new List<string>();
    public string name;
    public int points;
    
}
