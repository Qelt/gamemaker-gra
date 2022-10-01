using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie3 : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] public bool isGrounded = false;
    const float GroundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform GroundCheckCollider;
    
    public int WysokoscSkoku;
    public int PrednkoscPoruszania;
    
    public bool isHoldingJump = false;
    
    


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();

    }

    void GroundCheck()
    {
        isGrounded = false;
        Debug.Log("ground");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, GroundCheckRadius, groundLayer);
        if(colliders.Length>0)
        {
            isGrounded = true;
        }    
    }

}
