using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationManager
{
    public void PlayWalkingAnimation(GameObject gameObject){
        Animator animator = GetAnimatior(gameObject);
        animator.SetFloat("WalkSpeed", 1);
        StartAnimation(animator, "Walking");
    }

    public void StopWalkingAnimation(GameObject gameObject){
        Animator animator = GetAnimatior(gameObject);
        animator.SetFloat("WalkSpeed", 0);
        StopAnimation(animator, "Walking");
    }

    public void PlayAttackAnimation(GameObject gameObject){
        Animator animator = GetAnimatior(gameObject);
        StartAnimation(animator, "Attack");
    }

    public void PlayDeathAnimation(GameObject gameObject){
        Animator animator = GetAnimatior(gameObject);
        StartAnimation(animator, "Death");
    }

    //--------------------------------------------------------------

    private void StartAnimation(Animator animator, string trigger){
        animator.SetTrigger(trigger);
    }

    private void StopAnimation(Animator animator, string trigger){
        animator.ResetTrigger(trigger);
    }

    private Animator GetAnimatior(GameObject gameObject){
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator == null) { Debug.LogError("Tried to play animation on GameObject that doesn't have a Animator Component"); }
        return animator;
    }
}
