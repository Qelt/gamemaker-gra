using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingobjectCollider : MonoBehaviour
{
    [SerializeField]
    fallingObject odnosnikdofallingobject;
    void OnTriggerEnter2D(Collider2D other)
    {
        odnosnikdofallingobject.startAction();
        Debug.Log("falingObject");

    }
    
}
