using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangibleManager : MonoBehaviour
{
    [SerializeField] private ShadowCollider shadowEndPoint;
    [SerializeField] private GameObject platform;
    [SerializeField] private MeshRenderer boxCollider;


    private void Update()
    {
        if (platform.transform.position.z - 1 > shadowEndPoint.transform.position.z && platform.transform.position.z + 1 < shadowEndPoint.topVertice.z 
            || platform.transform.position.z + 1 < shadowEndPoint.transform.position.z && platform.transform.position.z - 1 > shadowEndPoint.topVertice.z)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
        }
        
        

    }
}
