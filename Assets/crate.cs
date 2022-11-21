using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crate : MonoBehaviour
{
    public GameObject ammoPrefab;
    public GameObject healthPrefab;
    public GameObject coinPrefab;
    public GameObject player;
    public GameObject smoke;
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
            GameObject expl = Instantiate(smoke, new Vector3(transform.position.x - 1f, transform.position.y, 0), Quaternion.identity);
            Destroy(expl, 1f);
            Destroy(gameObject);
            if (player.GetComponent<shooting>().ammo <= 2)
            {
                Instantiate(ammoPrefab, transform.position, ammoPrefab.transform.rotation);
            }
            else if (player.GetComponent<Health>().health <= 50f)
            { 
                Instantiate(healthPrefab, transform.position, healthPrefab.transform.rotation);
            }
            else
            {
                Instantiate(coinPrefab, transform.position, coinPrefab.transform.rotation);
                Instantiate(coinPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), coinPrefab.transform.rotation);
                Instantiate(coinPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), coinPrefab.transform.rotation);
            }
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
