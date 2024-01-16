using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DissolvingController : MonoBehaviour
{
    public MeshRenderer mesh;
    public VisualEffect VFXGraph;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    private Material[] meshMaterials;

    private Color fireDissolveColor = new Color(255, 84, 25);
    private Color waterDissolveColor = new Color(138, 224, 255);
    private Color natureDissolveColor = new Color(4, 255, 232);

    private Material material;

    void Start()
    {
        material = GetComponent<Material>();

        if (mesh != null)
            meshMaterials = mesh.materials;
        VFXGraph.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveCo());
        }
    }


    IEnumerator DissolveCo()
    {
        if (VFXGraph != null)
        {
            VFXGraph.Play();
        }

        if (meshMaterials.Length > 0)
        {
            float counter = 0;

            while (meshMaterials[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for (int i = 0; i < meshMaterials.Length; i++)
                {
                    meshMaterials[i].SetFloat("_DissolveAmount", counter);
                }

                yield return new WaitForSeconds(refreshRate);
            }
        }
    }

    public void Death()
    {
        StartCoroutine(DissolveCo());
    }

}
