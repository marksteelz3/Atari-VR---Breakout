using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public Transform sphere;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You are activating 'Touch' on the trigger");
        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You are activating 'TouchDown' on the trigger");
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You are activating 'TouchUp' on the trigger");
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You are activating 'Press' on the trigger");
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You are activating 'PressDown' on the trigger");
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You are activating 'PressUp' on the trigger");
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("You are activating 'PressUp' on the touchpad");
            sphere.transform.position = new Vector3(0, 1.3f, 0.5f);
            sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("You have collided with " + col.name + " and have activated OnTriggerStay");
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You have collided with " + col.name + " while holding down touch");
            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.SetParent(this.gameObject.transform);
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You have released touch while colliding with " + col.name);
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;

            tossObject(col.attachedRigidbody);
        }
    }

    void tossObject(Rigidbody rigidBody)
    {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidBody.velocity = origin.TransformVector(device.velocity);
            rigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
        else
        {
            rigidBody.velocity = (device.velocity)*2;
            rigidBody.angularVelocity = (device.angularVelocity)*2;
        }
    }
}
