using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;


public class Shoot : MonoBehaviour {

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    public GameObject bulletPref;
    public AudioClip shootSound;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        Shooting();
    }


    void Shooting()
    {
        cooldownTimer -= Time.deltaTime;
        if (CnInputManager.GetButtonDown("Shoot"))
        {
            source.Play();
            cooldownTimer = fireDelay;
            Instantiate(bulletPref, transform.position, transform.rotation);
        }
    }

}
