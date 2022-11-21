using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePointPrefab;
    public int ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && ammo > 0)
        {
            Instantiate(bulletPrefab, firePointPrefab.transform.position, bulletPrefab.transform.rotation);
            ammo -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ammo")
        {
            Destroy(col.gameObject);
            ammo = 6;
        }
    }
}
