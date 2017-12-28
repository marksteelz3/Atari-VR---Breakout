using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float initialVelocity;
    //public float minSpeed;

    public SteamVR_Controller controller;

    private Rigidbody rb;
    private bool inPlay;
	
	void Awake () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (inPlay == false && Time.time>13.4)
        {
            inPlay = true;
            Debug.Log("You have started the game");
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, 0, initialVelocity));
        }
    }

    /*
    void OnCollisionEnter(Collision other)
    {
        if (rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = rb.velocity * 1.3F;
        }
    }
    */
}
