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
    public float defaultspeed = 7f;
    public float fastspeed = 9f;
    public float slowspeed = 4.5f;
    
    //wykrywanie przeszkody
    public GameObject obstacleRayObject;
    [SerializeField] float rayDistance = 0.45f;
    public bool kolizja;
    
    //inne
    public bool pozaMapa;
    float przyspieszenie = 0;
    public int OnedeathSound = 1;

    coinPoints odnosnikdoCoinPoints;

    public bool isPlayerDeath = false;

    private bool fristGroundContakt = false;


    //audio
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource jumpLandingSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;

    //particle
    public ParticleSystem Ground;
    [SerializeField] ParticleSystem deathParticle;
    ZarzadzanieUI odnosnikDoZarzadzaniaUI;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        Time.timeScale = 1f;
        OnedeathSound = 1;
        odnosnikdoCoinPoints = FindObjectOfType<coinPoints>();
        odnosnikDoZarzadzaniaUI = FindObjectOfType<ZarzadzanieUI>();
    }

    private void FixedUpdate() 
    {
        przyspieszenie += 0.00000002f;
    }

    void Update()
    {
        GroundCheck();
        Sprawdzacze();
        //przyspieszenie += Time.deltaTime/110000 ;
        //przyspieszenie += 0.000000001f;
        przyspieszanieGry();

        if (kolizja == false)
        {
            Move();
            
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
            
        wykrywaniePrzeszkody();

        /*
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        */

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
            fristGroundContakt = true;

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
        if (fristGroundContakt == true)
        {
            transform.position += new Vector3(PrednkoscPoruszania, 0f ,0f) * Time.deltaTime;
        }
        
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
        if (pozaMapa == true )
        {
            isPlayerDeath = true;
        }
        
        if (isPlayerDeath == true && OnedeathSound == 1)
        {
            deathSoundEffect.Play();
            OnedeathSound -= 1;
            deathParticle.Play();
            odnosnikdoCoinPoints.activateSaveToJson();
            odnosnikDoZarzadzaniaUI.pointsSaveToJson();
            odnosnikDoZarzadzaniaUI.printBestScores();

        }

        if (isPlayerDeath == true)
        {
            Time.timeScale = 0f;
        }
    }

    void particleGround()
    {
        //Debug.Log("ground");
        var main = Ground.main;
        main.startColor = Color.red;
        Ground.Play();
    }

    public void playerDeath()
    {
        isPlayerDeath = true;
    }
}
