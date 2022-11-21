using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tnt : MonoBehaviour
{
    public GameObject player;
    public GameObject explosion;
    public float speed;
    private float difficulty;
    public bool explode;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player 1");
        difficulty = 10f;
        explode = false;
    }

    // Update is called once per frame
    void Update()
    {
        Slide();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            GameObject expl = Instantiate(explosion, new Vector3(transform.position.x - 1f, transform.position.y, 0), Quaternion.identity);
            Destroy(expl, 1f);
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {

        Destroy(gameObject);

    }

    void Slide()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        speed = (player.GetComponent<Health>().timeAlive / difficulty) + 5;

        if (speed >= 15)
        {
            speed = 15f;
        }

    }
}
