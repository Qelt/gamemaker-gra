using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZarzadzanieScenami2 : MonoBehaviour
{
    public void ZmienScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ScenaMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void goToShop()
    {
        SceneManager.LoadScene(2);
    }
}
