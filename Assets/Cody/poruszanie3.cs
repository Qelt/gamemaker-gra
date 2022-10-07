using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    
    [SerializeField] public bool isGrounded = false;
    const float GroundCheckRadius = 0.05f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform GroundCheckCollider;
    
    public float WysokoscSkoku = 500;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    public float PrednkoscPoruszania = 0.007f;
    public int HowManyJumps;
    
    public bool isHoldingJump;
    
    


    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        GroundCheck();
        Move();      
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            transform.position += new Vector3(0.008f ,0f ,0f);
        } if (Input.GetKeyDown(KeyCode.A))
        {
            PrednkoscPoruszania = PrednkoscPoruszania - 0.001f;
        }else
        {
            PrednkoscPoruszania = 0.007f;
        }
    }

    void GroundCheck()
    {
        isGrounded = false;
        //Debug.Log("ground");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, GroundCheckRadius, groundLayer);
        if(colliders.Length > 0)
        {
            //Debug.Log("ground");
            isGrounded = true;
            HowManyJumps = 1;
        }    
    }
    
    void Jump()
    {
        if (HowManyJumps > 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * WysokoscSkoku;
            HowManyJumps = HowManyJumps - 1;
           
           /*
            if (rb.velocity.y < 0)
            {
                Debug.Log("skok");
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; 
            } else if (rb.velocity.y > 0 && !Input.GetButton ("Jump"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            */
        }
        
    }

    void Move()
    {
        //Debug.Log("ruch");
        transform.position += new Vector3(PrednkoscPoruszania ,0f ,0f);
        //GetComponent<Rigidbody2D>().AddForce(New Vector2(3 ,0));
    }

    
    
}
