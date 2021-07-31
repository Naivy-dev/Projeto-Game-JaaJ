using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    float Yrot;
    RaycastHit hitPickup;
    GameObject grabbedObj;
    public Transform grabbedObjLocation;
    public LayerMask flashLimiter;
    public LayerMask player;

    private void Update()
    {
        Yrot -= Input.GetAxis("Mouse Y");
        Yrot = Mathf.Clamp(Yrot, -60, 60);
        transform.localRotation = Quaternion.Euler(Yrot, 0f, 0f);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hitPickup, 10, ~flashLimiter & ~player) && hitPickup.transform.GetComponent<Rigidbody>())
        {
            Debug.DrawLine(transform.position, hitPickup.point, Color.green);
            grabbedObj = hitPickup.transform.gameObject;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            grabbedObj.tag = "Box";
            grabbedObj = null;
            if (grabbedObj == null)
            {
                return;
            }
        }

        if (grabbedObj)
        {
            grabbedObj.tag = "GrabbedBox";
            grabbedObj.GetComponent<Rigidbody>().velocity = 10 * (grabbedObjLocation.position - grabbedObj.transform.position);
        }
    }
}