using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stair : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player 1");
        difficulty = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= -40f)
        {
            //Destroy(gameObject);
        }

        if (transform.position.x >= 30f)
        {
            //Destroy(gameObject);nj v b u
        }
        speed = (player.GetComponent<Health>().timeAlive / difficulty) + 5;

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
