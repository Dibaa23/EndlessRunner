using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.x >= 6f)
        {
            Destroy(gameObject);
        }
    }
}
