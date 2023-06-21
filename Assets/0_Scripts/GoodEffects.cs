using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEffects : MonoBehaviour
{
    GameObject obj;

    private GameObject _particlePref1;
    private GameObject _particleObj1;

    public GameObject head;
    public GameObject pants;
    public GameObject torso;

    SkinnedMeshRenderer meshRenderer1;
    SkinnedMeshRenderer meshRenderer2;
    SkinnedMeshRenderer meshRenderer3;

    [SerializeField] Material[] materials1;
    [SerializeField] Material[] materials2;
    [SerializeField] Material[] materials3;

    void Start()
    {
        obj = (GameObject)Resources.Load("GoodEffects");
        _particlePref1 = (GameObject)Resources.Load("TransformEffects");
        meshRenderer1 = head.GetComponent<SkinnedMeshRenderer>();
        meshRenderer2 = pants.GetComponent<SkinnedMeshRenderer>();
        meshRenderer3 = torso.GetComponent<SkinnedMeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject particle = Instantiate(obj, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 3.0f), Quaternion.identity);
            particle.transform.parent = this.transform;

            // エフェクトの位置を自分と同じ位置にする
            _particleObj1 = Instantiate(_particlePref1);
            _particleObj1.transform.position = transform.position;

            meshRenderer1.materials = materials1; // materials1 を適用
            meshRenderer2.materials = materials2; // materials1 を適用
            meshRenderer3.materials = materials3; // materials1 を適用

        }
    }
}
