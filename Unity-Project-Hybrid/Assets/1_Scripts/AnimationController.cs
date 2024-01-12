using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public string deathTrigger, attackTrigger, walkTrigger;

    private Animator animator;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            PlayDeathClip();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            PlayAttackClip();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            StartWalkingAnimation();
        }
    }

    public void PlayDeathClip() {
        animator.SetTrigger(deathTrigger);
    }

    public void PlayAttackClip() {
        animator.SetTrigger(attackTrigger);
    }

    public void StartWalkingAnimation() {
        animator.SetTrigger(walkTrigger);
    }
}
