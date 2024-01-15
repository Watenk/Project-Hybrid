using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureProjectile : MonoBehaviour, IProjectile
{
    public List<ParticleSystem> riseParticles;
    public Elements Element { get; private set; }
    public Elements ElementProjectile;

    private Animator animator;
    private Rigidbody rb;

    //--------------------------------------------------------

    public void Init(){
        Element = ElementProjectile;
        animator = GetComponentInChildren<Animator>();
        if (animator == null) { Debug.LogError("NatureProjectile is missing a Animator"); } 
        animator.StopPlayback();
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError("NatureProjectile is missing a RigidBody"); } 
    }

    public void Charge()
    {
        PlayRisingAnimation();
    }

    public void Shoot()
    {
        PlayShootAnimation();
    }

    public void Reset(){
        rb.velocity = Vector3.zero;
    }

    //-----------------------------------------------------------

    private void PlayRisingAnimation() {
        animator.SetTrigger("Rise");
        foreach(ParticleSystem particle in riseParticles) {
            particle.Play();
        }
        BobUpAndDown();
    }

    private void PlayShootAnimation() {
        rb.AddForce(this.gameObject.transform.forward * GameSettings.Instance.NatureProjectileSpeed);
        GetComponent<Rigidbody>().useGravity = true;
        LeanTween.cancelAll();
    }

    private void BobUpAndDown() {
        LeanTween.moveY(gameObject, 1, 1f).setEaseInOutSine().setLoopPingPong();
    }
}
