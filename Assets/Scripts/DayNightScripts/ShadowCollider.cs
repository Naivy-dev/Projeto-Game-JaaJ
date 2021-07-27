using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    [SerializeField] GameObject light;
    public Vector3[] vertices;

    public Vector3 topVertice;
    public Vector3 bottomVertice;
     void Update()
    {
        Vector3 lightDir = light.transform.rotation * light.transform.forward;

        Vector3 top = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y/2), transform.position.z);
        Vector3 bottom = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Ray raytop = new Ray(top, light.transform.forward);
        Ray raybottom = new Ray(bottom, transform.forward);
        RaycastHit hitInfo;
        
        
        

        if (Physics.Raycast(raytop, out hitInfo))
        {
            Debug.DrawLine(raytop.origin, hitInfo.point, Color.red);
            vertices = new Vector3[] { hitInfo.point };
            topVertice = vertices[0];
            Debug.Log(topVertice);
        }
        else
        {
            Debug.DrawLine(raytop.origin, raytop.origin + raytop.direction * 100, Color.green);
        }

        
        

    }

}
