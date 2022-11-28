using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZarzadzanieUI : MonoBehaviour
{
    public TextMeshProUGUI punktyWGrzeTekst;
    public TextMeshProUGUI punktyEkranKonca;
    float punkty;

    [SerializeField] private AudioSource punktSoundEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DodajPunkt()
    {
        punkty++;
        punktyWGrzeTekst.text = punkty.ToString();
        punktyEkranKonca.text = punkty.ToString();
        punktSoundEffect.Play();
        
    }
}

