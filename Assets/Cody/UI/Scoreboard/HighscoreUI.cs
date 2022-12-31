using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void ShowPanel() 
    {
        panel.SetActive (true);
    }

    public void ClosePanel() 
    {
        panel.SetActive(false);
    }
}
