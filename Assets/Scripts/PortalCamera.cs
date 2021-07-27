using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCam;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffset = playerCam.position - otherPortal.position;
        transform.position = portal.position + playerOffset;
        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCamDir = portalDiff * playerCam.forward;
        transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);
    }
}
