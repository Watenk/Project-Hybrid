using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour, IProjectile
{
    public Elements Element { get; private set; } = Elements.Water;
    private Rigidbody rb;
    public GameObject waterbeamPrefab;

    private float waterbeamTimer;
    private bool shot;
    private GameObject waterbeamInstance;
    private SoundManager soundManager;

    public void FixedUpdate(){
        if (shot == true){
            waterbeamTimer -= Time.deltaTime;

            if (waterbeamTimer <= 0){
                waterbeamInstance.SetActive(false);
            }
        }
    }

    public void Init(){
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError(this.name + " Doesn't contain a rigidbody"); }
        soundManager = GameManager.Instance.GetSoundManager();
    }

    public void Charge(){
        soundManager.PlaySound(GameSettings.Instance.WaterProjectileSummonSound, SoundSource.SFX1);
    }

    public void Shoot(){
        soundManager.PlaySound(GameSettings.Instance.WaterProjectileShootSound, SoundSource.SFX1);
        waterbeamTimer = 2.5f;
        shot = true;
        waterbeamInstance = Instantiate(waterbeamPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        waterbeamInstance.SetActive(true);
        rb.AddForce(this.gameObject.transform.forward * GameSettings.Instance.WaterProjectileSpeed);
    }

    public void Reset(){
       
        shot = false;
        Destroy(waterbeamInstance);
        rb.velocity = Vector3.zero;
        waterbeamPrefab.SetActive(false);
    }
}
