using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszanieKamery : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
        transform.position = new Vector3(player.position.x + 4, 0f, -10f);
    }
    
    
    /*public float moveSpeed = 0.001f;
    public Rigidbody2D rb;

    private void Update() 
    {
        transform.position += new Vector3(moveSpeed ,0f ,0f);
    }
    */
}
