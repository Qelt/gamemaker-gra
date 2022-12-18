using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class coinPoints : MonoBehaviour
{
    
    public coinSave coinsave = new coinSave();
    public TextMeshProUGUI coinPointsText;
    public float CoinPoints;
    
    public void addCoinPoint()
    {
        CoinPoints++;
        coinPointsText.text = CoinPoints.ToString();
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
}

[System.Serializable]
public class coinSave
{
    public int howManyCoins;
}