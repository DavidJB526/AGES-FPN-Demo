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

    public IInteractive LookedAtInteractive
    {
        get
        {
            return lookedAtInteractive;
        }
        set
        {
            lookedAtInteractive = value;
        }
    }

    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDetectRange, Color.green);

        RaycastHit hitInfo;
        bool objectDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxDetectRange);

        IInteractive interactive = null;

        LookedAtInteractive = interactive;

        if (objectDetected)
        {
            //Debug.Log($"Player is looking at: {hitInfo.collider.gameObject.name}");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        if (interactive != null)
        {
            lookedAtInteractive = interactive;
        }
    }
}
