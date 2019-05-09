using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField]
    private bool enableGravity;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            if (enableGravity)
            {
                rb.useGravity = true;
            }
            else if (!enableGravity)
            {
                rb.useGravity = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = true;
        }
    }
}
