using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    
    [SerializeField] public bool isGrounded = false;
    const float GroundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform GroundCheckCollider;
    
    public int WysokoscSkoku = 500;
    public float PrednkoscPoruszania = 0.007f;
    public int HowManyJumps;
    
    public bool isHoldingJump;
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        GroundCheck();
        Move();
        //Vector2 vtmp = new Vector2(Input.GetAxis("Horizontal"),0);
        //rb.AddForce(vtmp * Time.deltaTime * PrednkoscPoruszania);      
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void GroundCheck()
    {
        isGrounded = false;
        //Debug.Log("ground");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, GroundCheckRadius, groundLayer);
        if(colliders.Length > 0)
        {
            Debug.Log("ground");
            isGrounded = true;
            HowManyJumps = 2;
        }    
    }
    
    void Jump()
    {
        if (HowManyJumps > 0)
        {
            rb.AddForce(Vector2.up * WysokoscSkoku);
            HowManyJumps = HowManyJumps - 1;
            Debug.Log("skok");
        }
        
    }

    void Move()
    {
        //Debug.Log("ruch");
        transform.position += new Vector3(PrednkoscPoruszania ,0f ,0f);
        //GetComponent<Rigidbody2D>().AddForce(New Vector2(3 ,0));
    }

    
    
}
