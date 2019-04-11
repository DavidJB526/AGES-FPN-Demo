using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;

    private InventoryObject associatedInventoryObject;

    public InventoryObject AssociatedInventoryObject
    {
        get { return associatedInventoryObject; }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }
}
