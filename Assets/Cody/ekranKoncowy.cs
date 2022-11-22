using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ekranKoncowy : MonoBehaviour
{
    public GameObject panelKoncaGry;
    public GameObject Pause;
    
    poruszanie3 odnosnikDoPoruszaniaGracza; 
    
    // Start is called before the first frame update
    void Start()
    {
        odnosnikDoPoruszaniaGracza = FindObjectOfType<poruszanie3>();
        Pause.SetActive(false);
        Time.timeScale = 1f;
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

        if (Input.GetKey(KeyCode.Q))
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }

        
    }
    void koniecPausy()
        {
            Time.timeScale = 1f;
            Pause.SetActive(false);
        }
}
