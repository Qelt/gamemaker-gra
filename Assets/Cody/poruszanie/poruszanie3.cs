using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    
    //grand chack
    public bool isGrounded = false;
    const float GroundCheckRadius = 0.003f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform GroundCheckCollider;
    
    //skok
    [SerializeField] float WysokoscSkoku = 500;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    [SerializeField]float jumpTime;
    [SerializeField] Vector2 vecGravity;
    
    //poruszanie sie i ograniczenie skoku
    bool isJumping;
    float jumpCounter;
    private float PrednkoscPoruszania;
    public int HowManyJumps;
    public float defaultspeed;
    public float fastspeed;
    public float slowspeed;
    
    //wykrywanie przeszkody
    public GameObject obstacleRayObject;
    [SerializeField] float rayDistance;
    public bool kolizja;
    
    //inne
    public bool pozaMapa;
    float przyspieszenie = 0;
    public int OnedeathSound = 1;


    //audio
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource jumpLandingSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;

    //particle
    public ParticleSystem Ground;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        Time.timeScale = 1f;
        OnedeathSound = 1;
    }

    private void FixedUpdate() 
    {
        
    }

    void Update()
    {
        GroundCheck();
        Sprawdzacze();
        //przyspieszenie += Time.deltaTime/110000 ;
        przyspieszenie += 0.000000002f;
        przyspieszanieGry();

        if (kolizja == false)
        {
            Move();
        }
            
        wykrywaniePrzeszkody();

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log(PrednkoscPoruszania);
            PrednkoscPoruszania = fastspeed;
            //transform.position += new Vector3(0.0075f ,0f ,0f);

        } else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
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

        if (transform.position.y < -5)
        {
            pozaMapa = true;
            Time.timeScale = 0f;
        }

        
    }

    void GroundCheck()
    {
        isGrounded = false;
        //Debug.Log("ground");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, GroundCheckRadius, groundLayer);
        if(colliders.Length > 0 )
        {
            //Debug.Log("ground");
            isGrounded = true;
            HowManyJumps = 2;
            //jumpLandingSoundEffect.Play();

        }
    }
    
    void Jump()
    {
        if (HowManyJumps > 0)
        {
           // GetComponent<Rigidbody2D>().velocity = Vector2.up * WysokoscSkoku;
            HowManyJumps = HowManyJumps - 1;
            
            jumpSoundEffect.Play();

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

        }
        
    }

    void Move()
    {
        //Debug.Log("ruch");
        transform.position += new Vector3(PrednkoscPoruszania, 0f ,0f) * Time.deltaTime;
        //rb.MovePosition(rb.position +  Vector2.right * PrednkoscPoruszania);
    }

    void wykrywaniePrzeszkody()
    {
        
        
        RaycastHit2D hitObstacle = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right, rayDistance);

        if (hitObstacle.collider != null)
        {
            Debug.Log(hitObstacle.collider.gameObject.name);
            Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * hitObstacle.distance, Color.red );
            kolizja = true;
        }else
        {
            kolizja = false;
            Debug.Log("brak przeszkody");
            Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * hitObstacle.distance, Color.green );
        }
        
    }

    
    void przyspieszanieGry()
    {
        defaultspeed += przyspieszenie;
        fastspeed += przyspieszenie;
        slowspeed += przyspieszenie;
    }
    

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (isGrounded == true )
        {
            jumpLandingSoundEffect.Play();
            particleGround();
            
        }
    }

    private void Sprawdzacze()
    {
        if (pozaMapa == true && OnedeathSound == 1)
        {
            deathSoundEffect.Play();
            OnedeathSound -= 1;
        }
    }

    void particleGround()
    {
        Debug.Log("ground");
        var main = Ground.main;
        main.startColor = Color.red;
        Ground.Play();
    }
}
