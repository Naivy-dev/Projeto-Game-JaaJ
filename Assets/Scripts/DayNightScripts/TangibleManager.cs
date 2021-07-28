using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangibleManager : MonoBehaviour
{
    [SerializeField] private ShadowCollider shadowEndPoint;
    [SerializeField] private GameObject platform;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private MeshRenderer meshRend;


    private void Update()
    {
        if (this.tag == "lightAble")
        {
            if (platform.transform.position.z - 1 > shadowEndPoint.transform.position.z && platform.transform.position.z + 1 < shadowEndPoint.topVertice.z
            || platform.transform.position.z + 1 < shadowEndPoint.transform.position.z && platform.transform.position.z - 1 > shadowEndPoint.topVertice.z)
            {
                meshRend.enabled = false;
                boxCollider.isTrigger = false;
            }
            else
            {
                meshRend.enabled = true;
                boxCollider.isTrigger = true;
            }
        } else if (this.tag == "unLightable")
        {
            if (platform.transform.position.z - 1 > shadowEndPoint.transform.position.z && platform.transform.position.z + 1 < shadowEndPoint.topVertice.z
            || platform.transform.position.z + 1 < shadowEndPoint.transform.position.z && platform.transform.position.z - 1 > shadowEndPoint.topVertice.z)
            {
                meshRend.enabled = true;
                boxCollider.isTrigger = true;
            }
            else
            {
                meshRend.enabled = false;
                boxCollider.isTrigger = false;
            }
        }
        

    }
}
