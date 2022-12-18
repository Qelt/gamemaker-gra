using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObjectCollision : MonoBehaviour
{
    bool collisionWithPlayer = false;
    //[SerializeField] Transform CheckCollider;
    //[SerializeField] LayerMask playerLayer;
    //[SerializeField] float checkRadius = 0.1f;

    [SerializeField]poruszanie3 odnosnikdoporuszanie3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (collisionWithPlayer == true)
        {
            Debug.Log("collsion");
            odnosnikdoporuszanie3.playerDeath();
        }
    }
 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1.1")
        {
            collisionWithPlayer = true;
        }
    }
 
 
 /*
    void collisionCheck()
    {
        collisionWithPlayer = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(CheckCollider.position, checkRadius , playerLayer);
        if(colliders.Length > 0 )
        {
            //Debug.Log("ground");
            collisionWithPlayer = true;
            //jumpLandingSoundEffect.Play();

        }
    }
    */
}
