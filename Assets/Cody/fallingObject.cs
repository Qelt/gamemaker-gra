using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class fallingObject : MonoBehaviour
{
    public cameraShake cameraShaker;
    public bool move = false;
    private float fallingObjectSpeed = -7f;

    public float time = 1;

    private int howManyRepeat = 3;
    [SerializeField] ParticleSystem boom;
    [SerializeField] private AudioSource boomaudioefect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            transform.position += new Vector3(0f, fallingObjectSpeed ,0f) * Time.deltaTime;
        }

        
        if (transform.position.y < -5f)
        {
            fallingObjectSpeed = 0f;
            particleBoom();
            boomaudioefect.Play();
            StartCoroutine(cameraShaker.Shake(.15f, .4f));
            Debug.Log("boom");
            Debug.Log("shake");
        }
        
       
    }


    void FixedUpdate()
    {
        if (Time.timeScale < 0.01f)
        {
           //ParticleSystem.Simulate(Time.deltaTime, true, false);
        }
    }

    //public void Simulate(float t, bool withChildren = true, bool restart = true, bool fixedTimeStep = true);

    public void startAction()
    {                       
        move = true;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        fallingObjectSpeed = 0f;
        //boomaudioefect.Play();
        
        if (other.gameObject.CompareTag("Budynek"))
        {
            fallingObjectSpeed = 0f;
            particleBoom();
            Debug.Log("Sound");
            boomaudioefect.Play();
            StartCoroutine(cameraShaker.Shake(.15f, .4f));
        }
    }
}
