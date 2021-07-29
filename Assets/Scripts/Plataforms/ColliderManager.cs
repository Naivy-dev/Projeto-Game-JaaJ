using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private RangeColliderPreset Preset;
    [SerializeField] private GameObject Obj;
    private Collider[] colliders;
    private Material MatBefore;
    private Material MatAfter;
    private MeshRenderer[] material;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = Obj.GetComponent<Animator>();
        colliders = Obj.GetComponentsInChildren<Collider>();
        material = Obj.GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Collider c in colliders)
        {
            if (Preset.isCollidable)
                c.enabled = true;
            else
                c.enabled = false;        
        }

        if (Preset.isCollidable)
            anim.SetBool("IsCollidable", true);
        else
        {
            anim.SetBool("IsCollidable", false);
            //ChangeMaterial();
        }

    }

    void ChangeMaterial()
    {
        foreach (MeshRenderer m in material)
        {
            if (Preset.isCollidable)
                m.material = MatAfter;
            else
                m.material = MatBefore;
        }
    }
}
