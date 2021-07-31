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

    private void Update()
    {
        Yrot -= Input.GetAxis("Mouse Y");
        Yrot = Mathf.Clamp(Yrot, -60, 60);
        transform.localRotation = Quaternion.Euler(Yrot, 0f, 0f);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hitPickup, 10, ~flashLimiter) && hitPickup.transform.GetComponent<Rigidbody>())
        {
            grabbedObj = hitPickup.transform.gameObject;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            grabbedObj.tag = "Box";
            grabbedObj = null;
        }

        if (grabbedObj)
        {
            grabbedObj.tag = "GrabbedBox";
            grabbedObj.GetComponent<Rigidbody>().velocity = 10 * (grabbedObjLocation.position - grabbedObj.transform.position);
        }
    }
}