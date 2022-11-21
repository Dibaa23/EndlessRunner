using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float difficulty;
    public float originalY;
    public float floatStrength;
    public float floatSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player 1");
        difficulty = 10f;
        this.originalY = this.transform.position.y;
        floatStrength = Random.Range(0.05f, 0.25f);
        floatSpeed = Random.Range(4, 8);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x,originalY + ((float)Mathf.Sin(floatSpeed * Time.time) * floatStrength), transform.position.z);
        if (transform.position.x <= -19f)
        {
            //Destroy(gameObject);
        }

        if (transform.position.x >= 50f)
        {
            //Destroy(gameObject);
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
