using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public string OAuth;
    public bool single = true;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
