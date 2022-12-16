using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action5 : MonoBehaviour
{
    public GameObject fallingObject;
    public GameObject coin;
    private int ratio;

    void Start()
    {
        ratio = Random.Range( 2, 3);
        if (ratio == 1)
        {
            Instantiate(coin, new Vector3(0f, Random.Range(-350f, 350f), 0), Quaternion.Euler(0, 0, 0)) ;
            Destroy(this.fallingObject);
            
        }else if (ratio == 2)
        {
            transform.position += new Vector3(Random.Range(-8f, 8f), 0f, 0f);
            //Instantiate(fallingObject, new Vector3(0f, Random.Range(-300f, 300f), 0), Quaternion.Euler(0, 0, 0)) ;
            Destroy(this.coin);
            
        }else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
