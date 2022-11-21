using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPScounter : MonoBehaviour
{
    public float avgFrameRate;
    public TMPro.TextMeshProUGUI display;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
    }

    // Update is called once per frame
    void Update()
    {
        float currentFPS = 0;
        currentFPS = (1f / Time.unscaledDeltaTime);
        avgFrameRate = currentFPS;
        display.text = avgFrameRate.ToString("0") + " FPS";
    }
}
