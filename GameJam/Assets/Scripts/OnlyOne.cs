using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyOne : MonoBehaviour
{
    public static OnlyOne instance;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

}
