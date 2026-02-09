using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)

    CustomGrab otherHand = null;

    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;

    public InputActionReference action;
    bool grabbing = false;

    // For two‑hand manipulation
    Vector3 lastPos;
    Quaternion lastRot;

    Vector3 otherLastPos;
    Quaternion otherLastRot;

    bool wasGrabbingLastFrame = false;

    private void Start()
    {
        action.action.Enable();

        // Find the other hand
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }

        lastPos = transform.position;
        lastRot = transform.rotation;
    }

    void Update()
    {
        grabbing = action.action.IsPressed();

        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                // If both hands are grabbing the same object → two‑hand manipulation
                if (otherHand.grabbing && otherHand.grabbedObject == grabbedObject)
                {
                    // Compute deltas for both hands
                    Vector3 myDeltaPos = transform.position - lastPos;
                    Quaternion myDeltaRot = transform.rotation * Quaternion.Inverse(lastRot);

                    Vector3 otherDeltaPos = otherHand.transform.position - otherLastPos;
                    Quaternion otherDeltaRot = otherHand.transform.rotation * Quaternion.Inverse(otherLastRot);

                    // Apply average movement
                    grabbedObject.position += (myDeltaPos + otherDeltaPos) * 0.5f;

                    // Combine rotations
                    Quaternion combinedRot = Quaternion.Slerp(myDeltaRot, otherDeltaRot, 0.5f);
                    grabbedObject.rotation = combinedRot * grabbedObject.rotation;
                }
                else
                {
                    // One‑hand manipulation (default behavior)
                    Vector3 deltaPos = transform.position - lastPos;
                    Quaternion deltaRot = transform.rotation * Quaternion.Inverse(lastRot);

                    grabbedObject.position += deltaPos;
                    grabbedObject.rotation = deltaRot * grabbedObject.rotation;
                }
            }
        }
        else if (grabbedObject)
        {
            // Release object
            grabbedObject = null;
        }

        // Save current transforms for next frame
        lastPos = transform.position;
        lastRot = transform.rotation;

        otherLastPos = otherHand.transform.position;
        otherLastRot = otherHand.transform.rotation;

        wasGrabbingLastFrame = grabbing;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Remove(t);
    }
}


