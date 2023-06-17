using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsTest : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    bool changeMat = true; // 初期値を true に設定

    [SerializeField] Material[] materials1;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && changeMat) // changeMat が true の場合にのみ切り替える
        {
            changeMat = false;
            meshRenderer.materials = materials1; // materials1 を適用
        }
    }
}
