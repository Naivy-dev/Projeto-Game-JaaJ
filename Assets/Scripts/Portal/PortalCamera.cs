using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCam;
    public Transform portal;
    public Transform otherPortal;
    public Camera portalCam;
    public Material portalMat;
    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffset = playerCam.position - otherPortal.position;
        if (playerCam.position.z >= -16)
        {
            portalMat.mainTexture = portalCam.targetTexture;
            transform.position = portal.position + playerOffset;
            float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);
            Quaternion portalDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
            Vector3 newCamDir = portalDiff * playerCam.forward;
            transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);

        }
        else
        {
            portalMat.mainTexture = null;
        }
        
    }
}
