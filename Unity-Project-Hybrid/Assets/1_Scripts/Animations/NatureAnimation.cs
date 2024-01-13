using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureAnimation : MonoBehaviour
{
    public float thrustPower;
    public List<ParticleSystem> riseParticles;

    private Animator animator;
    
    void Start(){
        animator = transform.GetChild(0).GetComponent<Animator>();
        animator.StopPlayback();
    }

    public void PlayRisingAnimation() {
        animator.SetTrigger("Rise");
        foreach(ParticleSystem particle in riseParticles) {
            particle.Play();
        }
        BobUpAndDown();
    }

    public void PlayShootAnimation(Transform playerPosition) {
        gameObject.transform.GetComponent<Rigidbody>().AddForce(transform.position - new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z) * thrustPower);
        GetComponent<Rigidbody>().useGravity = true;
        LeanTween.cancelAll();
    }

    private void BobUpAndDown() {
        LeanTween.moveY(gameObject, 1, 1f).setEaseInOutSine().setLoopPingPong();
    }
}
