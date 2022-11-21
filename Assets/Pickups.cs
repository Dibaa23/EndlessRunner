using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            coins += 1;
        }
    }
}
