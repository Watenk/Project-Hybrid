using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public string deathTrigger, attackTrigger, walkTrigger;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void PlayDeathClip() {
        animator.SetTrigger(deathTrigger);
    }

    public void PlayAttackClip() {
        animator.SetTrigger(attackTrigger);
    }

    public void PlayWalkingAnimation() {
        animator.SetTrigger(walkTrigger);
    }

    public void PlayIdleAnimation(){
        animator.StopPlayback();
    }
}
