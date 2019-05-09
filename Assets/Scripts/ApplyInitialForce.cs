using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyInitialForce : MonoBehaviour
{
    [SerializeField]
    private Vector3 startForce;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (rb != null)
        {
            rb.AddForce(startForce);
        }
    }
}
