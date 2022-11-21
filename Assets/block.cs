using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player 1");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= -19f)
        {
            //Destroy(gameObject);
        }

        if (transform.position.x >= 18f)
        {
            //Destroy(gameObject);
        }

        speed = (player.GetComponent<Health>().timeAlive / 10) + 5;

        if (speed >= 15)
        {
            speed = 15f;
        }
    }

    void OnBecameInvisible()
    {

        Destroy(gameObject);

    }
}
