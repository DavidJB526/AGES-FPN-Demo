using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    // TODO: Add long description field
    // TODO: Add icon field

    public string ObjectName => objectName;

    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    /// <summary>
    /// When the player interacts with an inventory object, we need to do 2 things:
    /// 1. Add the inventory object to the PlayerInventory list
    /// 2. Remove the ojbect from the game world / scene
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InvetoryObjects.Add(this);
        renderer.enabled = false;
        collider.enabled = false;
    }
}
