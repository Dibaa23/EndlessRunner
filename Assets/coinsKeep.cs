using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinsKeep : MonoBehaviour
{
    public GameObject Player;
    public TMPro.TextMeshProUGUI coinsTxt;

    // Start is called before the first frame update
    void Start()
    {
        coinsTxt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        coinsTxt.text = Player.GetComponent<Pickups>().coins.ToString();
    }
}
