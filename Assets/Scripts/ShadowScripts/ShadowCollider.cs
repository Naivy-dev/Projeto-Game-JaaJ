using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    [SerializeField] GameObject sunLight;
    public Vector3[] vertices;
    public Vector3 topVertice;
    void Update()
    {        
        Vector3 top = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y / 2), transform.position.z);
        Ray raytop = new Ray(top, sunLight.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(raytop, out hitInfo))
        {
            Debug.DrawLine(raytop.origin, hitInfo.point, Color.red);
            vertices = new Vector3[] { hitInfo.point };
            topVertice = vertices[0];
        }
        else
        {
            Debug.DrawLine(raytop.origin, raytop.origin + raytop.direction * 100, Color.green);
        }
    }
}
