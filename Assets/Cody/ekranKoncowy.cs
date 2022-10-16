using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ekranKoncowy : MonoBehaviour
{
    public GameObject panelKoncaGry;
    
    poruszanie3 odnosnikDoPoruszaniaGracza; 
    
    // Start is called before the first frame update
    void Start()
    {
        odnosnikDoPoruszaniaGracza = FindObjectOfType<poruszanie3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (odnosnikDoPoruszaniaGracza.pozaMapa == true)
        {
            panelKoncaGry.SetActive(true);
        }else
        {
            panelKoncaGry.SetActive(false);
        }
    }
}
