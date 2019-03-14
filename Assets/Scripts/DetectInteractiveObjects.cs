using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInteractiveObjects : MonoBehaviour
{
    [SerializeField]
    private Transform raycastOrigin;
    [SerializeField]
    private float maxDetectRange = 5.0f;
    [SerializeField]
    private int layerToIgnore = 9;

    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDetectRange, Color.green);

        RaycastHit hitInfo;
        bool objectDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxDetectRange);

        if (objectDetected)
        {
            Debug.Log(hitInfo.collider.gameObject.name);
        }
    }
}
