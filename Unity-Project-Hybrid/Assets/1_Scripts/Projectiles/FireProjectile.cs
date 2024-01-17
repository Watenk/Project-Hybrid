using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour, IProjectile
{
    public Elements Element { get; private set; } = Elements.Fire;

    public LayerMask agentLayer;

    private Rigidbody rb;
    private GameObject target;

    public void Init(){
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError("NatureProjectile is missing a RigidBody"); } 
    }

    public void Charge(){
        StartCoroutine(SummonFireball());
    }

    public void Shoot(){
        FindFireballTarget();
    }

    public void Reset(){
        rb.velocity = Vector3.zero;
    }


    IEnumerator SummonFireball()
    {
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        transform.GetChild(0).gameObject.SetActive(false);
        rb.useGravity = false;
        transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();

        float duration = 1.5f;
        float timeElapsed = 0;


        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            float size = Mathf.Lerp(0.05f, 0.3f, t);
            transform.localScale = new Vector3(size, size, size);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }


    private void FindFireballTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, transform.TransformDirection(Vector3.forward), out hit, 100, agentLayer))
        {
            Debug.DrawRay(Camera.main.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");

            target = hit.transform.gameObject;
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
        transform.parent = null;

        Vector3 velocity = Vector3.zero;

        float duration = 1.5f;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;

            Vector3 position = Vector3.SmoothDamp(targetPos, transform.position, ref velocity, t / 200);
            transform.position = position;

            float size = Mathf.Lerp(0.3f, 4f, t);
            transform.localScale = new Vector3(size, size, size);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        if (timeElapsed >= duration)
            StartCoroutine(ReleaseFireball());
    }


    IEnumerator ReleaseFireball()
    {
        rb.useGravity = true;

        yield return new WaitForSeconds(0.4f);

        target.GetComponent<DissolvingController>().Death();
        transform.GetChild(0).gameObject.SetActive(true);
    }



}
