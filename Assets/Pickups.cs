using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class Pickups : MonoBehaviour
{
    public float coins;
    public VolumeProfile mVolumeProfile;
    public Vignette mVignette;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        for (int i = 0; i < mVolumeProfile.components.Count; i++)
        {
            if (mVolumeProfile.components[i].name == "Vignette")
            {
                mVignette = (Vignette)mVolumeProfile.components[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && coins > 0)
        {
            Time.timeScale = 0.5f;
            ClampedFloatParameter intensity = mVignette.intensity;
            intensity.value = 0.25f;
            coins -= (4 * Time.deltaTime);
        }
        else {
            Time.timeScale = 1;
            ClampedFloatParameter intensity = mVignette.intensity;
            intensity.value = 0.1f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            if (coins < 50) {
                coins += 1;
            }
        }
    }
}
