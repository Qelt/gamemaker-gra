using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforma2 : MonoBehaviour
{
    public float distance = 10;
    [SerializeField]
    private float lifetime= 60f;
    ZarzadzanieUI odnosnikDoZarzadzaniaUI;

    private int oneRepeat = 1;

    private void Start() 
    {
        Destroy(this.gameObject, lifetime);
        odnosnikDoZarzadzaniaUI = FindObjectOfType<ZarzadzanieUI>();
        oneRepeat = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneRepeat == 1)
        {
        Debug.Log("trigger");
        //GenerowaniePlatform.Instance.UtworzPlatforme(distance);
        GenerowaniePlatformStaraWersja.Instance.UtworzPlatforme();
        odnosnikDoZarzadzaniaUI.DodajPunkt();
        oneRepeat -= 1;
        }
    }

}

