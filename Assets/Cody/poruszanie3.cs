using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    
    public bool isGrounded = false;
    const float GroundCheckRadius = 0.05f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform GroundCheckCollider;
    
    [SerializeField] float WysokoscSkoku = 500;
    
    
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    [SerializeField]float jumpTime;
    [SerializeField] Vector2 vecGravity;
    
    bool isJumping;
    float jumpCounter;


    private float PrednkoscPoruszania;
    public int HowManyJumps;

    public float defaultspeed;
    public float fastspeed;
    public float slowspeed;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() 
    {
         
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
            Debug.Log(PrednkoscPoruszania);
            PrednkoscPoruszania = fastspeed;
            //transform.position += new Vector3(0.0075f ,0f ,0f);

        } else if (Input.GetKey(KeyCode.A))
        {
            PrednkoscPoruszania = slowspeed;
        }else
        {
            PrednkoscPoruszania = defaultspeed;
        }

         if (rb.velocity.y < 0)
            {
                rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
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
           // GetComponent<Rigidbody2D>().velocity = Vector2.up * WysokoscSkoku;
            HowManyJumps = HowManyJumps - 1;
            
            
            rb.velocity = new Vector2(rb.velocity.x, WysokoscSkoku);
            isJumping = true;
            jumpCounter = 0;

            if (rb.velocity.y > 0 && isJumping) 
            {
                jumpCounter+= Time.deltaTime;
                if (jumpCounter > jumpTime) isJumping = false;

                rb.velocity += Vector2.up * lowJumpMultiplier * Time.deltaTime;
            }

            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
            }

           
            
           
            /*if (rb.velocity.y < 0)
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
        transform.position += new Vector3(PrednkoscPoruszania, 0f ,0f) * Time.deltaTime;
        //rb.MovePosition(rb.position +  Vector2.right * PrednkoscPoruszania);
    }

    
    
}
