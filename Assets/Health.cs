using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject camera;
    public Image bloodImage;
    public Rigidbody2D rb;
    public float timeAlive;
    public float health;
    public bool getDamage;
    

    // Start is called before the first frame update
    void Start()
    {
        timeAlive = 0f;
        health = 100f;
        getDamage = false;

    }   

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        if (health <= 0f)
        {   
            SceneManager.LoadScene("Game Over");
        }

        if (getDamage)
        {
            Color Opaque = new Color(1, 0, 0, 1);
            bloodImage.color = Color.Lerp(bloodImage.color, Opaque, 20 * Time.deltaTime);
            if (bloodImage.color.a >= 0.75) 
            {
                getDamage = false;
            }
        }
        if (!getDamage)
        {
            Color Transparent = new Color(1, 1, 1, 0);
            bloodImage.color = Color.Lerp(bloodImage.color, Transparent, 20 * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spike")
        {
            getDamage = true;
            health -= 15f;
        }
        if (col.gameObject.tag == "Lava")
        {
            getDamage = true;
            health -= 5f;
        }
        if (col.gameObject.tag == "Health")
        {
            Destroy(col.gameObject);
            health += 25f;
        }
    }

    void OnBecameInvisible()
    {
        SceneManager.LoadScene("Game Over");
    }
}
