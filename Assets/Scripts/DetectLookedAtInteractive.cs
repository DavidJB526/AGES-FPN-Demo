using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookedAtInteractive : MonoBehaviour
{
    [SerializeField]
    private Transform raycastOrigin;
    [SerializeField]
    private float maxDetectRange = 5.0f;
    //[SerializeField]
    //private int layerToIgnore = 9;

    /// <summary>
    /// Event raised when the player looks at a different IInteractive.
    /// </summary>
    public static event Action<IInteractive> LookedAtInteractiveChanged;

    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = (value != lookedAtInteractive);
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);
            }
        }
    }

    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        LookedAtInteractive = GetLookedAtInteractive();
    }

    /// <summary>
    /// Raycasts forward from the camera to look for IInteractives.
    /// </summary>
    /// <returns>The first IInteractive detected or null if none are found.</returns>
    private IInteractive GetLookedAtInteractive()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDetectRange, Color.green);

        RaycastHit hitInfo;
        bool objectDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxDetectRange);
        Debug.Log(objectDetected);

        IInteractive interactive = null;

        if (objectDetected)
        {
            //Debug.Log($"Player is looking at: {hitInfo.collider.gameObject.name}");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        Debug.Log(interactive);
        return interactive;
    }
}
