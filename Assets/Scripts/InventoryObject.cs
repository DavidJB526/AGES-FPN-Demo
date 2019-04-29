using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [SerializeField]
    [TextArea(3,8)]
    private string description;

    [SerializeField]
    private Sprite icon;

    public string ObjectName => objectName;
    public string Description => description;
    public Sprite Icon => icon;

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
        InventoryMenu.Instance.AddItemToMenu(this);
        renderer.enabled = false;
        collider.enabled = false;
        Debug.Log($"Inventory menu game object name {InventoryMenu.Instance.name}");
    }
}
