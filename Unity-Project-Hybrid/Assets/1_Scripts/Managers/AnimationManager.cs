using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager
{
    public void PlayWalkingAnimation(GameObject gameObject){
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator == null) { Debug.LogError("Tried to play animation on GameObject that doesn't have a Animator Component"); }
        StartAnimation(animator, "Walking");
    }

    public void StopWalkingAnimation(GameObject gameObject){
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator == null) { Debug.LogError("Tried to play animation on GameObject that doesn't have a Animator Component"); }
        StopAnimation(animator, "Walking");
    }

    //--------------------------------------------------------------

    private void StartAnimation(Animator animator, string trigger){
        animator.SetTrigger(trigger);
    }

    private void StopAnimation(Animator animator, string trigger){
        animator.ResetTrigger(trigger);
    }
}
