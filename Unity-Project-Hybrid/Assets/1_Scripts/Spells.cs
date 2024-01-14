using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public LayerMask enemyLayer;

    public GameObject fireball, waterbeam;
    private int fireballPhase = 1;
    private int waterbeamPhase = 0;
    private GameObject currentAttack;
    private GameObject target;


    public float spellCooldown = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switch (fireballPhase)
            {
                case 0:
                    Debug.Log("fireball available");
                    fireballPhase++;
                    break;
                case 1:
                    Debug.Log("summon fireball");
                    fireballPhase++;
                    StartCoroutine(SummonFireball());
                    break;
                case 2:
                    Debug.Log("wait for summoning");
                    break;
                case 3:
                    Debug.Log("can select target");
                    FindFireballTarget();
                    break;
                case 4:
                    Debug.Log("wait for moving fireball");
                    break;
                case 5:
                    Debug.Log("release fire");
                    fireballPhase++;
                    StartCoroutine(ReleaseFireball());
                    break;
                case 6:
                    Debug.Log("wait for attack cooldown");
                    break;
            }
        }

        if (waterbeamPhase == 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            waterbeamPhase = 1;
            StartCoroutine(SummonWaterbeam());
        }

    }


    IEnumerator SummonFireball()
    {
        currentAttack = Instantiate(fireball, Camera.main.transform.position + (transform.forward * 3) - (transform.up * 1), transform.rotation, transform);
        currentAttack.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();

        float duration = 1.5f;
        float timeElapsed = 0;


        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            float size = Mathf.Lerp(0.1f, 0.5f, t);
            currentAttack.transform.localScale = new Vector3(size, size, size);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        if (timeElapsed >= duration)
            fireballPhase++;
    }


    private void FindFireballTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, transform.TransformDirection(Vector3.forward), out hit, 100, enemyLayer))
        {
            Debug.DrawRay(Camera.main.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");

            target = hit.transform.gameObject;
            fireballPhase++;
            StartCoroutine(MoveFireball(hit.transform.position + (transform.up * 5)));
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    IEnumerator MoveFireball(Vector3 targetPos)
    {
        currentAttack.transform.parent = null;

        Vector3 oldPos = currentAttack.transform.position;
        

        float duration = 1.5f;
        float timeElapsed = 0;


        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;

            Vector3 position = Vector3.Lerp(oldPos, targetPos, t);
            currentAttack.transform.position = position;

            float size = Mathf.Lerp(0.5f, 1f, t);
            currentAttack.transform.localScale = new Vector3(size, size, size);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        if (timeElapsed >= duration)
            fireballPhase++;
    }


    IEnumerator ReleaseFireball()
    {
        currentAttack.GetComponent<Rigidbody>().useGravity = true;

        yield return new WaitForSeconds(0.4f);
        
        target.GetComponent<DissolvingController>().Death();
        currentAttack.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(spellCooldown);
        Destroy(currentAttack);
        fireballPhase = 0;
    }


    IEnumerator SummonWaterbeam()
    {
        currentAttack = Instantiate(waterbeam, Camera.main.transform.position + (transform.forward * 3) - (transform.up * 2), transform.rotation, transform);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, transform.TransformDirection(Vector3.forward), out hit, 100, enemyLayer))
        {
            Debug.DrawRay(Camera.main.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");

            target = hit.transform.gameObject;
            target.GetComponent<DissolvingController>().Death();
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

        yield return new WaitForSeconds(3);
        Destroy(currentAttack);

        yield return new WaitForSeconds(spellCooldown);
        waterbeamPhase = 0;
    }


}
