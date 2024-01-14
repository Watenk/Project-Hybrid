using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager
{
    public void StartAnimation(Animator animator, string trigger){
        animator.SetTrigger(trigger);
    }

    public void StopAnimation(Animator animator, string trigger){
        animator.ResetTrigger(trigger);
    }

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

    //     public float thrustPower;
    // public List<ParticleSystem> riseParticles;

    // private Animator animator;
    
    // void Start(){
    //     animator = transform.GetChild(0).GetComponent<Animator>();
    //     animator.StopPlayback();
    // }

    // public void PlayRisingAnimation() {
    //     animator.SetTrigger("Rise");
    //     foreach(ParticleSystem particle in riseParticles) {
    //         particle.Play();
    //     }
    //     BobUpAndDown();
    // }

    // public void PlayShootAnimation(Transform playerPosition) {
    //     gameObject.transform.GetComponent<Rigidbody>().AddForce(transform.position - new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z) * thrustPower);
    //     GetComponent<Rigidbody>().useGravity = true;
    //     LeanTween.cancelAll();
    // }

    // private void BobUpAndDown() {
    //     LeanTween.moveY(gameObject, 1, 1f).setEaseInOutSine().setLoopPingPong();
    // }
}
