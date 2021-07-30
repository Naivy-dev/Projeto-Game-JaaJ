using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightMechanic : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    public Vector3[] vertices;
    public Vector3 topVertice;
    public RaycastHit hitInfo;
    public LayerMask player;
    public float flashLightRange = 20;

    void Update()
    {
        Ray raytop = new Ray(flashlight.transform.position, flashlight.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(raytop, out hitInfo, flashLightRange, ~player))
        {
            Debug.DrawLine(raytop.origin, hitInfo.point, Color.red);
            vertices = new Vector3[] { hitInfo.point };
            topVertice = vertices[0];
            this.hitInfo = hitInfo;
        }
        else
        {
            Debug.DrawLine(raytop.origin, raytop.origin + raytop.direction * 100, Color.green);
        }
    }
}
