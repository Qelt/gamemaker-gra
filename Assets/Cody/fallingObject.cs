using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObject : MonoBehaviour
{
    public bool move = false;
    private float fallingObjectSpeed = -7f;

    private int howManyRepeat = 3;
    [SerializeField] ParticleSystem boom;

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

        if (transform.position.y < -0.5f)
        {
            fallingObjectSpeed = 0f;
            particleBoom();
        }
    }

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
}
