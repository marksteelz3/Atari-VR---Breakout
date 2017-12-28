using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    public float speed;
    public Transform sphere;

    void OnTriggerEnter (Collider col)
    {
        GameManager.instance.LoseLife();
        sphere.transform.position = new Vector3(0,1.3f,0.5f);
        sphere.GetComponent<Rigidbody>().velocity = new Vector3(0,0,speed);
        sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
