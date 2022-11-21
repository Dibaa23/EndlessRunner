using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoBox : MonoBehaviour
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
        if (transform.position.x <= -18f)
        {
            //Destroy(gameObject);
        }
        speed = (player.GetComponent<Health>().timeAlive / difficulty) + 5;
    }

    void OnBecameInvisible()
    {

        Destroy(gameObject);

    }

}
