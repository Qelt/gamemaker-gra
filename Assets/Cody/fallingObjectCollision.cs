using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObjectCollision : MonoBehaviour
{
    bool collisionWithPlayer = false;
    //[SerializeField] Transform CheckCollider;
    //[SerializeField] LayerMask playerLayer;
    //[SerializeField] float checkRadius = 0.1f;

    public CameraShake cameraShaker;
    poruszanie3 odnosnikDoPoruszaniaGracza;
    [SerializeField] ParticleSystem boom;
    [SerializeField] private AudioSource boomaudioefect;
    private int howManyRepeat = 10;
    // Start is called before the first frame update
    void Start()
    {
        odnosnikDoPoruszaniaGracza = FindObjectOfType<poruszanie3>();
    }

    void Update()
    {
        if (collisionWithPlayer == true)
        {
            Debug.Log("collsion");
            odnosnikDoPoruszaniaGracza.playerDeath();
            particleBoom();
            boomaudioefect.Play();
            StartCoroutine(cameraShaker.Shake(.15f, .4f));
            Debug.Log("shake");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(cameraShaker.Shake(.15f, .4f));
            Debug.Log("shake");
        }
    }
 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1.1")
        {
            collisionWithPlayer = true;
        }
    }

    void particleBoom()
    {
        if (howManyRepeat > 0)
        {
            var main = boom.main;
            boom.Play();
            howManyRepeat -= 1;
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
