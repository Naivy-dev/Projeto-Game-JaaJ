using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMechanic : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    public Vector3[] vertices;
    public Vector3 topVertice;
    public RaycastHit hitInfo;

    void Update()
    {
        Ray raytop = new Ray(flashlight.transform.position, flashlight.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(raytop, out hitInfo))
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
