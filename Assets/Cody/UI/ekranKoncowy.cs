using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ekranKoncowy : MonoBehaviour
{
    public GameObject panelKoncaGry;
    public GameObject Pause;
    public GameObject scoreBoard;
    
    poruszanie3 odnosnikDoPoruszaniaGracza; 
    

    public void koniecPausy()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
        Debug.Log("stop");
    }

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
            scoreBoard.SetActive(true);
        }else
        {
            panelKoncaGry.SetActive(false);
            scoreBoard.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }

        
    }
}