using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerowaniePlatformStaraWersja : MonoBehaviour
{
    public static GenerowaniePlatformStaraWersja Instance;

    public GameObject Platformax;
    public GameObject Platforma1x;
    public GameObject Platforma2x;
    public GameObject Platforma3x;
    public GameObject Platforma4x;
    public GameObject Platforma5x;
    public GameObject Platforma6x;
    public GameObject Platforma7x;
    public GameObject Platforma8x;
    public GameObject Platforma9x;
    public GameObject Platforma10x;
    public float odstep = 20; 

    private int losowaniePlatfomy;
    float przyspieszenie = 0;

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
        for (int i = 0; i < 10; i++)
        {
            UtworzPlatforme();
        }
    }

    private void Update()
    {
        
        //odstep += przyspieszenie;
    }
    
    public void UtworzPlatforme()
    {
        przyspieszenie += 0.0025f ;
        
        losowaniePlatfomy = Random.Range( 1, 10);
        
        if ( losowaniePlatfomy == 1)
        {
            UtworzPlatforme1();
        } else if ( losowaniePlatfomy == 2)
        {
            UtworzPlatforme2();
        } else if ( losowaniePlatfomy == 3)
        {
            UtworzPlatforme3();
        }else if (losowaniePlatfomy == 4)
        {
            UtworzPlatforme4();
        }else if (losowaniePlatfomy == 5)
        {
            UtworzPlatforme5();
        }else if (losowaniePlatfomy == 6)
        {
            UtworzPlatforme6();
        }else if (losowaniePlatfomy == 7)
        {
            UtworzPlatforme7();
        }else if (losowaniePlatfomy == 8)
        {
            UtworzPlatforme8();
        }else if (losowaniePlatfomy == 9)
        {
            UtworzPlatforme9();
        }else if (losowaniePlatfomy == 10)
        {
            UtworzPlatforme10();
        }
    }

    public void UtworzPlatforme1()
    {
        Instantiate(Platforma1x, new Vector3(odstep + 1  , Random.Range(-6f, -4f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 11 + przyspieszenie;
    }

    public void UtworzPlatforme2()
    {
        Instantiate(Platforma2x, new Vector3(odstep + 2, Random.Range(-4f, -2f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 11 + przyspieszenie;
    }

    public void UtworzPlatforme3()
    {
        Instantiate(Platforma3x, new Vector3(odstep + 2, Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 11 + przyspieszenie;
    }

    public void UtworzPlatforme4()
    {
        Instantiate(Platforma4x, new Vector3(odstep + 1, Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 11 + przyspieszenie;
    }

    public void UtworzPlatforme5()
    {
        Instantiate(Platforma5x, new Vector3(odstep - 8, Random.Range( -2f, 1f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 20 + przyspieszenie;
    }

    public void UtworzPlatforme6()
    {
        Instantiate(Platforma6x, new Vector3(odstep + 1, Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 11 + przyspieszenie;
    }

    public void UtworzPlatforme7()
    {
        Instantiate(Platforma7x, new Vector3(odstep - 7, Random.Range( -2f, 1f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 22 + przyspieszenie;
    }

    public void UtworzPlatforme8()
    {
        Instantiate(Platforma8x, new Vector3(odstep - 7, Random.Range( -2f, 1f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 21 + przyspieszenie;
    }

    public void UtworzPlatforme9()
    {
        Instantiate(Platforma9x, new Vector3(odstep + 1 , Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 11 + przyspieszenie;
    }

    public void UtworzPlatforme10()
    {
        Instantiate(Platforma10x, new Vector3(odstep - 1, Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 12 + przyspieszenie;
    }
}
