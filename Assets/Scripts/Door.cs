using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [SerializeField]
    private bool isLocked;
    [SerializeField]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    private AudioClip doorOpenClip;
    [SerializeField]
    private AudioClip doorLockedClip;

    public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

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
    }

    public override void InteractWith()
    {
        if (!isLocked)
        {
            audioSource.clip = doorOpenClip;
            anim.SetBool(shouldOpenAnimParameter, !anim.GetBool(shouldOpenAnimParameter));
        }
        else
        {
            audioSource.clip = doorLockedClip;
        }

        base.InteractWith();
    }
}
