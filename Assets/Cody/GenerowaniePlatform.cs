using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerowaniePlatform : MonoBehaviour
{
    public static GenerowaniePlatform Instance;

    public GameObject Platforma;
    public float odstep = 0; 

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            
        } else Instance = this;
        Debug.Log(Instance);
    }

    private void Start() 
    {
        for (int i = 0; i < 5; i++)
        {
            UtworzPlatforme();
        }
    }

    public void UtworzPlatforme()
    {
        Instantiate(Platforma, new Vector3(odstep, Random.Range(-2.5f, 2.5f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 10;
    }
}