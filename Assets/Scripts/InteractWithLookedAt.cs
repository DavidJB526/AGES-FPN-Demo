using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the Interact button while looking at an IInteractive
/// and then calls that IInteract's InteractWith method.
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    private DetectInteractiveObjects detectInteractiveObjects;

    private void Start()
    {
        detectInteractiveObjects = this.gameObject.GetComponent<DetectInteractiveObjects>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && detectInteractiveObjects.LookedAtInteractive != null)
        {
            Debug.Log($"Player pressed the Interact button");
            detectInteractiveObjects.LookedAtInteractive.InteractWith();
        }
    }
}
