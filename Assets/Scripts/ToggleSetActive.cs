using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [SerializeField]
    private GameObject objectToToggle;
    [SerializeField]
    private bool isReusable = true;

    private bool hasBeenUsed = false;

    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            hasBeenUsed = true;
            if (!isReusable)
            {
                displayText = string.Empty;
            }
        }
    }
}
