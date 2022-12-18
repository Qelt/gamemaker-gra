using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class coinPoints : MonoBehaviour
{
    
    public coinSave coinsave = new coinSave();
    public TextMeshProUGUI coinPointsText;

    public TextMeshProUGUI menuCoinAmount;
    public float CoinPointsLive;

    public float totalCoinPoints;
    
    void Awake()
    {
        LoadFromJson();
    }

    public void addCoinPoint()
    {
        CoinPointsLive++;
        coinPointsText.text = CoinPointsLive.ToString();
    }

    public void activateSaveToJson()
    {
        SaveToJson();
        
    }

    public void SaveToJson()
    {
        
        string coinData = JsonUtility.ToJson(coinsave);
        string filePath = Application.persistentDataPath + "/CoinSave.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, coinData);
        Debug.Log("Save Sukces");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/CoinSave.json";
        string coinData = System.IO.File.ReadAllText(filePath);

        coinsave = JsonUtility.FromJson<coinSave>(coinData);
        Debug.Log("Sukces Load Coin Data");
    }
}

[System.Serializable]
public class coinSave
{
    public int howManyCoins;

}