using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerowaniePlatform : MonoBehaviour
{
    public static GenerowaniePlatform Instance;

    [SerializeField]
    private Platforma2[] platformPrefabs;

    public GameObject Platforma;
    public GameObject Platforma1;
    public GameObject Platforma2;
    public GameObject Platforma3;
    public GameObject Platforma4;
    public GameObject Platforma5;
    public GameObject Platforma6;
    public GameObject Platforma7;
    public GameObject Platforma8;
    public GameObject Platforma9;
    public GameObject Platforma10;
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
            UtworzPlatforme(20);
        }
    }

    private void Update()
    {
        
        //odstep += przyspieszenie;
    }
    
    public void UtworzPlatforme(float lastPlatformLength)
    {
        przyspieszenie += 0.0025f ;
        
        losowaniePlatfomy = Random.Range( 0, platformPrefabs.Length);

        Instantiate(platformPrefabs[losowaniePlatfomy].gameObject, new Vector3(odstep + 1, Random.Range(-6f, -4f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += platformPrefabs[losowaniePlatfomy].distance + przyspieszenie;
    
        return;
        
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
        Instantiate(Platforma1, new Vector3(odstep + 1, Random.Range(-6f, -4f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 9 + przyspieszenie;
    }

    public void UtworzPlatforme2()
    {
        Instantiate(Platforma2, new Vector3(odstep - 4, Random.Range(-2f, 0f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 10 + przyspieszenie;
    }

    public void UtworzPlatforme3()
    {
        Instantiate(Platforma3, new Vector3(odstep + 6, Random.Range(-6f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 9 + przyspieszenie;
    }

    public void UtworzPlatforme4()
    {
        Instantiate(Platforma4, new Vector3(odstep - 2, Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 10 + przyspieszenie;
    }

    public void UtworzPlatforme5()
    {
        Instantiate(Platforma5, new Vector3(odstep - 9, Random.Range( -2f, 1f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 21 + przyspieszenie;
    }

    public void UtworzPlatforme6()
    {
        Instantiate(Platforma6, new Vector3(odstep - 3, Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 9 + przyspieszenie;
    }

    public void UtworzPlatforme7()
    {
        Instantiate(Platforma7, new Vector3(odstep - 9, Random.Range( -2f, 1f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 21 + przyspieszenie;
    }

    public void UtworzPlatforme8()
    {
        Instantiate(Platforma8, new Vector3(odstep - 9, Random.Range( -2f, 1f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 21 + przyspieszenie;
    }

    public void UtworzPlatforme9()
    {
        Instantiate(Platforma9, new Vector3(odstep - 1, Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 12 + przyspieszenie;
    }

    public void UtworzPlatforme10()
    {
        Instantiate(Platforma10, new Vector3(odstep - 1, Random.Range(-5f, -3f), 0), Quaternion.Euler(0, 0, 0)) ;
        odstep += 12 + przyspieszenie;
    }
}
