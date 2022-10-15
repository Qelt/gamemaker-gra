using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerowaniePlatform : MonoBehaviour
{
    public static GenerowaniePlatform Instance;

    public GameObject Platforma;
    public GameObject Platforma1;
    public GameObject Platforma2;
    public GameObject Platforma3;
    public float odstep = 20; 

    private int losowaniePlatfomy;

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
        losowaniePlatfomy = Random.Range( 1, 4);

        if ( losowaniePlatfomy == 1)
        {
            UtworzPlatforme1();
        } else if ( losowaniePlatfomy == 2)
        {
            UtworzPlatforme2();
        } else if ( losowaniePlatfomy == 3)
        {
            UtworzPlatforme3();
        }
    }

    public void UtworzPlatforme1()
    {
        Instantiate(Platforma1, new Vector3(odstep, Random.Range(-6f, -2f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 12;
    }

    public void UtworzPlatforme2()
    {
        Instantiate(Platforma2, new Vector3(odstep - 4, Random.Range(-2f, 3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 14;
    }

    public void UtworzPlatforme3()
    {
        Instantiate(Platforma3, new Vector3(odstep + 5, Random.Range(-6f, -2f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 12;
    }
}
