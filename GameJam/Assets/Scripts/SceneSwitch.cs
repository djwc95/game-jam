using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadStore1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLvl1()
    {
        SceneManager.LoadScene(3);
    }
}