using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ZarzadzanieUI : MonoBehaviour
{
    public TextMeshProUGUI punktyWGrzeTekst;
    public TextMeshProUGUI punktyEkranKonca;
    public int punkty;
    public pointsSave pointssave = new pointsSave();
    public string scoreBordpoints;

    [SerializeField] private AudioSource punktSoundEffect;
    [SerializeField] TextMeshProUGUI ScorebordText;
    [SerializeField] HighscoreElement highscoreElement;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pointsLoadFromJson();
    }

    // Update is called once per frame
    void Update()
    {
        //pointssave.name = "Test"; //+" " + pointssave.points;
    }

    public void DodajPunkt()
    {
        punkty++;
        punktyWGrzeTekst.text = punkty.ToString();
        punktyEkranKonca.text = punkty.ToString();
        punktSoundEffect.Play();
        //pointssave.points++;
        highscoreElement.points++;
        
    }

    public void pointsSaveToJson()
    {     
    //pointssave.logFromGame.Add(pointssave.name);
    //pointssave.intlogFromGame.Add(punkty);
    //pointssave.highscoreList.Add(highscoreElement.points);

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

    public void printBestScores()
    {
        //foreach( var x in pointssave.intlogFromGame) Debug.Log( x.ToString(scoreBordpoints));
        //ScorebordText.text = pointssave.intlogFromGame.ToString();
    }
}

[System.Serializable]
public class pointsSave
{
    
    public List<HighscoreElement> highscoreList = new List<HighscoreElement>();
    
    /*
    public List<string> logFromGame = new List<string>();
    public List<int> intlogFromGame = new List<int>();
    public string name;
    public int points;
    */
}


[Serializable]
public class HighscoreElement
{
    public string playerName;
    public int points;

    public HighscoreElement (string name, int points)
    {
        playerName = name;
        this.points = points;
    }

}
