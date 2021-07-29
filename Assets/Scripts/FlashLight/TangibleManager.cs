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
        float semiScale = platform.transform.localScale.z / 2;
        if (this.tag == "lightAble")
        {
            if (platform.transform.position.z - semiScale > shadowEndPoint.transform.position.z && platform.transform.position.z + semiScale < shadowEndPoint.topVertice.z
            || platform.transform.position.z + semiScale < shadowEndPoint.transform.position.z && platform.transform.position.z - semiScale > shadowEndPoint.topVertice.z)
            {
                meshRend.enabled = true;
                gameObject.layer = 7;
                boxCollider.isTrigger = false;
            }
            else
            {
                meshRend.enabled = false;
                gameObject.layer = 0;
                boxCollider.isTrigger = true;
            }
        }
        else if (this.tag == "unLightable")
        {
            if (platform.transform.position.z - semiScale > shadowEndPoint.transform.position.z && platform.transform.position.z + semiScale < shadowEndPoint.topVertice.z
            || platform.transform.position.z + semiScale < shadowEndPoint.transform.position.z && platform.transform.position.z - semiScale > shadowEndPoint.topVertice.z)
            {
                meshRend.enabled = false;
                gameObject.layer = 0;
                boxCollider.isTrigger = true;
            }
            else
            {
                meshRend.enabled = true;
                gameObject.layer = 7;
                boxCollider.isTrigger = false;
            }
        }


    }
}
