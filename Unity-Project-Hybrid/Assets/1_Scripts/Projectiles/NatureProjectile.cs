using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureProjectile : MonoBehaviour, IProjectile
{
    public List<ParticleSystem> riseParticles;
    public Elements Element { get; private set; } = Elements.Nature;

    private Animator animator;
    private Rigidbody rb;
    private SoundManager soundManager;

    //--------------------------------------------------------

    public void Init(){
        animator = GetComponentInChildren<Animator>();
        if (animator == null) { Debug.LogError("NatureProjectile is missing a Animator"); } 
        animator.StopPlayback();
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError("NatureProjectile is missing a RigidBody"); } 
        soundManager = GameManager.Instance.GetSoundManager();
    }

    public void Charge()
    {
        soundManager.PlaySound(GameSettings.Instance.NatureProjectileSummonSound, SoundSource.SFX1);
        PlayRisingAnimation();
    }

    public void Shoot()
    {
        soundManager.PlaySound(GameSettings.Instance.NatureProjectileShootSound, SoundSource.SFX1);
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
