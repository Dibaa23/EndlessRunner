using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeBar : MonoBehaviour
{
    public Image Bar;
    public GameObject Player;
    public float timeNum;

    // Start is called before the first frame update
    void Start()
    {
        timeNum = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeNum = Player.GetComponent<Pickups>().coins;
        Bar.fillAmount = timeNum / 50f;
    }
}
