using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    [SerializeField] private float grabRange = 2f;
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private KeyCode grabKey = KeyCode.G;

    private GameObject grabbedObject;
    private Rigidbody grabbedRigidbody;

    private void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            if (grabbedObject == null)
                TryGrab();
            else
                Release();
        }

        if (grabbedObject != null)
        {
            grabbedObject.transform.position = holdPoint.position;
        }
    }

    private void TryGrab()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, grabRange);
        float closestDistance = grabRange;
        GameObject closest = null;

        foreach (var col in colliders)
        {
            float dist = Vector3.Distance(transform.position, col.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = col.gameObject;
            }
        }

        if (closest != null)
        {
            grabbedObject = closest;
            grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
            if (grabbedRigidbody != null)
                grabbedRigidbody.isKinematic = true;
        }
    }

    private void Release()
    {
        if (grabbedRigidbody != null)
        {
            grabbedRigidbody.isKinematic = false;
            grabbedRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }

        grabbedObject = null;
        grabbedRigidbody = null;
    }
}
