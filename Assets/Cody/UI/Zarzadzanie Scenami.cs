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

    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void goToShop()
    {
        SceneManager.LoadScene(2);
    }
}
