using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private int ratio;
    private int oneRepeat = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ratio = Random.Range( 1, 2);
        if (ratio == 1)
        {
            transform.position += new Vector3(Random.Range( -500f, 350f) ,0f) * Time.deltaTime;
            
        }else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (oneRepeat == 1)
        {
            Destroy(this);
            oneRepeat -= 1;
            Debug.Log("coin trigger");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneRepeat == 1)
        {
        Destroy(this.gameObject);
        oneRepeat -= 1;
        Debug.Log("coin trigger");
        }
    }
}
