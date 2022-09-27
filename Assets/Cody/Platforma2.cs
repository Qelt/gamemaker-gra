using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforma2 : MonoBehaviour
{
    [SerializeField]
    private float lifetime= 30f;
    private void Start() 
    {
        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        GenerowaniePlatform.Instance.UtworzPlatforme();
    }

}

