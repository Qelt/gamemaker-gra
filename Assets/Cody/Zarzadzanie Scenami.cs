using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZarzadzanieScenami : MonoBehaviour
{
    public void ZmienScene()
    {
        SceneManager.LoadScene(0);
    }
}
