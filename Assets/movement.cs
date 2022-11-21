using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpHeight;
    public int jumpCount;
    public float gravityScale;
    public float fallingGravityScale;
    public int jumpMax;
   // public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 0;
        jumpHeight = 12f;
        jumpMax = 2;
        gravityScale = 4f;
        fallingGravityScale = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && jumpCount < jumpMax)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            jumpCount += 1;
        }

        if (rb.velocity.y >= 0)
        {
            //dust.Play();
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            //dust.Stop();
            rb.gravityScale = fallingGravityScale;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            jumpMax = 2;
        }

        if (col.gameObject.tag == "PowerUp")
        {
            Destroy(col.gameObject);
            jumpMax = 99;
        }
    }
}
