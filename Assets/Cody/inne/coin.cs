using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private int oneRepeat = 1;
    coinPoints odnosnikDoCoinPoints;
    [SerializeField] ParticleSystem particleMonetka;
    [SerializeField] AudioSource dzwienkMonetka;
    
    // Start is called before the first frame update
    void Start()
    {
        odnosnikDoCoinPoints = FindObjectOfType<coinPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (oneRepeat == 1)
        {
            Destroy(this);
            oneRepeat -= 1;
            Debug.Log("coin trigger");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneRepeat == 1)
        {
        odnosnikDoCoinPoints.addCoinPoint();
        particleMonetka.Play();
        dzwienkMonetka.Play();
        var main = particleMonetka.main;
        Destroy(this.gameObject);
        oneRepeat -= 1;
        Debug.Log("coin trigger");
        
        }
    }
}
