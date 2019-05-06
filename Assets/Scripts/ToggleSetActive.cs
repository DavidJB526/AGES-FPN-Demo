using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [SerializeField]
    private GameObject[] objectsToToggle;
    [SerializeField]
    private bool isReusable = true;

    private bool hasBeenUsed = false;

    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractWith();
            foreach (GameObject ob in objectsToToggle)
            {
                ob.SetActive(!ob.activeSelf);
            }
            hasBeenUsed = true;
            if (!isReusable)
            {
                displayText = string.Empty;
            }
        }
    }
}
