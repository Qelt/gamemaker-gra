using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class coinPoints : MonoBehaviour
{
    public TextMeshProUGUI coinPointsText;
    float CoinPoints;
    

    public void addCoinPoint()
    {
        CoinPoints++;
        coinPointsText.text = CoinPoints.ToString();
    }
}
