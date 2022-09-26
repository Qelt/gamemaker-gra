using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszanieKamery : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
}
