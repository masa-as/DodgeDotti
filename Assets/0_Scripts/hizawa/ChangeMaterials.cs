using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsTest : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    bool changeMat = true; // ‰Šú’l‚ğ true ‚Éİ’è

    [SerializeField] Material[] materials1;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && changeMat) // changeMat ‚ª true ‚Ìê‡‚É‚Ì‚İØ‚è‘Ö‚¦‚é
        {
            changeMat = false;
            meshRenderer.materials = materials1; // materials1 ‚ğ“K—p
        }
    }
}
