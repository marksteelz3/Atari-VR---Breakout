using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public Transform sphere;
    public GameObject brickParticle;
    public AudioClip aud;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(aud, 1F);
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
