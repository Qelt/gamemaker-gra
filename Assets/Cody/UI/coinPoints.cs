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

    public int item1Price = 10;
    public int item2Price = 1;
    public int item3Price = 2;

    Shop odnosnikDoShop;
    
    void Awake()
    {
        LoadFromJson();
        menuCoinAmount.text = coinsave.howManyCoins.ToString();
        odnosnikDoShop = FindObjectOfType<Shop>();
    }

    public void addCoinPoint()
    {
        CoinPointsLive++;
        coinPointsText.text = CoinPointsLive.ToString();
        coinsave.howManyCoins++;
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

    public void buyItem1()
    {
        if (coinsave.howManyCoins > item1Price)
        {
            coinsave.howManyCoins -= item1Price;
            odnosnikDoShop.item1();
            menuCoinAmount.text = coinsave.howManyCoins.ToString();
        }
    }

    public void buyItem2()
    {
        if (coinsave.howManyCoins > item2Price)
        {
            coinsave.howManyCoins -= item2Price;
            odnosnikDoShop.item2();
            menuCoinAmount.text = coinsave.howManyCoins.ToString();
        }
    }

    public void buyItem3()
    {
        if (coinsave.howManyCoins > item3Price)
        {
            coinsave.howManyCoins -= item3Price;
            odnosnikDoShop.item3();
            menuCoinAmount.text = coinsave.howManyCoins.ToString();
        }
    }

}

[System.Serializable]
public class coinSave
{
    public int howManyCoins;

}