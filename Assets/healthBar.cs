using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image Bar;
    public GameObject Player;
    public float healthValue;

    // Start is called before the first frame update 
    void Start()
    {
        healthValue = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        healthValue = Player.GetComponent<Health>().health;
        Bar.fillAmount = healthValue / 100f;
    }
}
