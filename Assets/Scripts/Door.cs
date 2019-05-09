using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [SerializeField]
    private InventoryObject key;
    [SerializeField]
    private bool isLocked;
    [SerializeField]
    private bool consumesKey;
    [SerializeField]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    private AudioClip doorOpenClip;
    [SerializeField]
    private AudioClip doorLockedClip;

    //public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    public override string DisplayText
    {
        get
        {
            string toReturn;

            if (isLocked)
            {
                toReturn = HasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
            }
            else
            {
                toReturn = base.DisplayText;
            }

            return toReturn;
        }
    }

    private bool HasKey => PlayerInventory.InvetoryObjects.Contains(key);

    private Animator anim;
    private int shouldOpenAnimParameter = Animator.StringToHash("shouldOpen");

    /// <summary>
    /// Using a contructor here to initialize displayText in the Editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null || isLocked)
        {
            isLocked = true;
        }
        else
        {
            isLocked = false;
        }
    }

    public override void InteractWith()
    {
        if (isLocked && !HasKey)
        {
            audioSource.clip = doorLockedClip;
        }
        else
        {
            UnlockDoor();
            audioSource.clip = doorOpenClip;
            anim.SetBool(shouldOpenAnimParameter, !anim.GetBool(shouldOpenAnimParameter));
        }

        base.InteractWith();
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
        {
            PlayerInventory.InvetoryObjects.Remove(key);
        }
    }
}
