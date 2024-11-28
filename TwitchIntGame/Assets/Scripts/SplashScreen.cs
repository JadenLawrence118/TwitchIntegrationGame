using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private Image UWELogo;
    [SerializeField] private Image UnityLogo;
    [SerializeField] private TextMeshProUGUI DevName;

    private void Awake()
    {
        Color newColour = UWELogo.color;
        newColour.a = 0f;
        UWELogo.color = newColour;
        UnityLogo.color = newColour;
        DevName.color = newColour;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        // changes alpha value of logos
        if (UWELogo.material.color.a < 246)
        {
            Color newColour = UWELogo.color;
            newColour.a += 0.001f;
            UWELogo.color = newColour;
            UnityLogo.color = newColour;
            DevName.color = newColour;
        }

        StartCoroutine(Wait());
    }
}
