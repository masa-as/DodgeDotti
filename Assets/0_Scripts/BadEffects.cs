using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEffects : MonoBehaviour
{
    public GameObject head;
    public GameObject pants;
    public GameObject torso;

    SkinnedMeshRenderer meshRenderer1;
    SkinnedMeshRenderer meshRenderer2;
    SkinnedMeshRenderer meshRenderer3;

    [SerializeField] Material[] materials1;

    void Start()
    {
        meshRenderer1 = head.GetComponent<SkinnedMeshRenderer>();
        meshRenderer2 = pants.GetComponent<SkinnedMeshRenderer>();
        meshRenderer3 = torso.GetComponent<SkinnedMeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            meshRenderer1.materials = materials1; // materials1 を適用
            meshRenderer2.materials = materials1; // materials1 を適用
            meshRenderer3.materials = materials1; // materials1 を適用

        }
    }
}
