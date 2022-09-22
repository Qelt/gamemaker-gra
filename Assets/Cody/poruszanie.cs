using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie : MonoBehaviour
{
    private Rigidbody2D rb;
    public int WysokoscSkoku;
    public int PrednkoscPoruszania;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vtmp = new Vector2(Input.GetAxis("Horizontal"),0);
        rb.AddForce(vtmp * Time.deltaTime * PrednkoscPoruszania);
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * WysokoscSkoku);
        }

    }
}