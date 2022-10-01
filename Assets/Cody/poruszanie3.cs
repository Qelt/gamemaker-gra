using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie3 : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] public bool isGrounded = false;
    const float GroundCheckRadius = 0.5f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform GroundCheckCollider;
    
    public int WysokoscSkoku = 5;
    public float PrednkoscPoruszania;
    
    public bool isHoldingJump = false;
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Move();
        Vector2 vtmp = new Vector2(Input.GetAxis("Horizontal"),0);
        rb.AddForce(vtmp * Time.deltaTime * PrednkoscPoruszania);      
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("skok");
            Jump();
        }
    }

    void GroundCheck()
    {
        isGrounded = false;
        //Debug.Log("ground");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, GroundCheckRadius, groundLayer);
        if(colliders.Length>0)
        {
            isGrounded = true;
        }    
    }
    
    void Jump()
    {
        rb.AddForce(Vector2.up * WysokoscSkoku);
    }

    void Move()
    {
        Debug.Log("ruch");
        transform.position += new Vector3(PrednkoscPoruszania ,0f ,0f);
        //GetComponent<Rigidbody2D>().AddForce(New Vector2(3 ,0));
    }
}
