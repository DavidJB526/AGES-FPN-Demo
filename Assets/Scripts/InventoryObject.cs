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

    private new Renderer[] renderers;
    private new Renderer[] childRenderers;
    private new Collider[] colliders;
    private new Light light;

    private void Start()
    {
        renderers = GetComponents<Renderer>();
        childRenderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponents<Collider>();
        light = GetComponentInChildren<Light>();
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
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }
        foreach (Renderer r in childRenderers)
        {
            r.enabled = false;
        }
        foreach (Collider c in colliders)
        {
            c.enabled = false;
        }
        light.enabled = false;
        Debug.Log($"Inventory menu game object name {InventoryMenu.Instance.name}");
    }
}
