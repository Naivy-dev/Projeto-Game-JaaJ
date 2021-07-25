using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    [SerializeField] GameObject light;

     void Update()
    {
        Vector3 lightDir = light.transform.rotation * light.transform.forward;

        Vector3 topLeft = new Vector3(transform.position.x - (transform.localScale.x / 2), transform.position.y + (transform.localScale.y/2), transform.position.z);
        Vector3 topRight = new Vector3(transform.position.x + (transform.localScale.x / 2), transform.position.y + (transform.localScale.y / 2), transform.position.z);

        Ray rayTopLeft = new Ray(topLeft, lightDir);
        Ray rayTopRight = new Ray(topRight, lightDir);
        RaycastHit hitInfo;

        

        if (Physics.Raycast(rayTopLeft, out hitInfo))
        {
            Debug.DrawLine(rayTopLeft.origin, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(rayTopLeft.origin, rayTopLeft.origin + rayTopLeft.direction * 100, Color.green);
        }

        if (Physics.Raycast(rayTopRight, out hitInfo))
        {
            Debug.DrawLine(rayTopRight.origin, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(rayTopRight.origin, rayTopRight.origin + rayTopRight.direction * 100, Color.green);
        }

    }


}
