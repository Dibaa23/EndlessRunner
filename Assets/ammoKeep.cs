using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ammoKeep : MonoBehaviour
{
    public GameObject Player;
    public TMPro.TextMeshProUGUI ammoTxt;

    // Start is called before the first frame update
    void Start()
    {
        ammoTxt.text = "6";
    }

    // Update is called once per frame
    void Update()
    {
        ammoTxt.text = Player.GetComponent<shooting>().ammo.ToString();
    }
}
