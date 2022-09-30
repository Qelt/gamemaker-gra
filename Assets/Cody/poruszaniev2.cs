using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszaniev2 : MonoBehaviour
{

    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJUmpTimer = 0.0f;

    public float jummpGroundThreshould = 1;

    
    void Start()
    {


    }

    void Update()
    {  
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);
        if (isGrounded || groundDistance <= jummpGroundThreshould) 
        { 
          if (Input.GetKeyDown(KeyCode.Space))
            { 
                 isGrounded = false;
                 velocity.y = jumpVelocity;
                 isHoldingJump = true;
                 holdJUmpTimer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
          isHoldingJump = false;
        }
    }
    
    private void FixedUpdate()
    {
       Vector2 pos = transform.position;

       if (!isGrounded)    
        {
            if (isHoldingJump)
            {
                holdJUmpTimer += Time.fixedDeltaTime;
                if (holdJUmpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }
         
         pos.y += velocity.y * Time.fixedDeltaTime;
         if (!isHoldingJump)
         {

            velocity.y += gravity * Time.fixedDeltaTime;
         }

         if (pos.y <= groundHeight)
         {
            pos.y = groundHeight;
            isGrounded = true;
         }
        }
       transform.position = pos;
    }
}
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    





