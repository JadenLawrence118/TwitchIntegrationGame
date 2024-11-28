using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    private Globals global;

    void Awake()
    {
        global = GameObject.Find("Globals").GetComponent<Globals>();
    }
    public void PlayStream()
    {
        global.single = false;
        SceneManager.LoadScene(4);
    }
    public void PlaySingle()
    {
        global.single = true;
        SceneManager.LoadScene(5);
    }
    public void LoadInstr()
    {
        SceneManager.LoadScene(3);
    }
    public void BackHome()
    {
        SceneManager.LoadScene(1);
    }
    public void Login()
    {
        string input = GameObject.Find("inputLogin").GetComponent<TMP_InputField>().text;

        if (input != "")
        {
            global.OAuth = input;
        }

        SceneManager.LoadScene(5);
    }
    public void InstrStream() 
    {
        SceneManager.LoadScene(2);
    }
    public void InstrSingle()
    {
        SceneManager.LoadScene(3);
    }
}
