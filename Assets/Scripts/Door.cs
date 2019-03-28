using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
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
        base.InteractWith();
        anim.SetBool(shouldOpenAnimParameter, !anim.GetBool(shouldOpenAnimParameter));
    }
}
