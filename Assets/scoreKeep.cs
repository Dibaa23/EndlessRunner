using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreKeep : MonoBehaviour
{
    public GameObject Player;
    public TMPro.TextMeshProUGUI scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = Player.GetComponent<Health>().timeAlive.ToString("0.00");
    }
}
