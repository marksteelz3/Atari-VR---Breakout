using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWallBounce : MonoBehaviour {

    public GameObject sphere;
    public AudioClip aud;
    public float bounceVel;

    private Rigidbody rb;
    private AudioSource source;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        source.PlayOneShot(aud, 1F);
        sphere.GetComponent<Rigidbody>().velocity = sphere.GetComponent<Rigidbody>().velocity + new Vector3(0, -bounceVel, 0);
    }
}
