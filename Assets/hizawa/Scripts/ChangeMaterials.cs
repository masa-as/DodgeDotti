using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsTest : MonoBehaviour
{
    SkinnedMeshRenderer MeshRenderer;
    bool changeMat = false;
    [SerializeField] Material[] materials1;
    [SerializeField] Material[] materials2;


    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            changeMat = !changeMat;
            MeshRenderer.materials = changeMat ? materials2 : materials1;

        }
    }
}