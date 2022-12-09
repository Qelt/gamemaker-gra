using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingobjectCollider : MonoBehaviour
{
    fallingObject odnosnikdofallingobject;
    void OnTrigerEnter2D(Collision2D other)
    {
        odnosnikdofallingobject.startAction();
        Debug.Log("falingObject");

    }
    
}
