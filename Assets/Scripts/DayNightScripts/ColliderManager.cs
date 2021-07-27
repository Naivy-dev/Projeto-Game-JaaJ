using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private RangeColliderPreset Preset;
    [SerializeField] private GameObject Obj;
    private Collider[] colliders;
    [SerializeField] private Material ObjMat;
    [SerializeField] private Color32 defaultColor;
    [SerializeField] private Color32 activeColor;

    // Start is called before the first frame update
    void Start()
    {
        colliders = Obj.GetComponentsInChildren<Collider>();     
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
        {
            ObjMat.color = activeColor;
            
        }

        else
        {
            ObjMat.color = defaultColor;
        }
    }
}
