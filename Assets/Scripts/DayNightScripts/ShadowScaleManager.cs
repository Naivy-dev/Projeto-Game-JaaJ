using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScaleManager : MonoBehaviour
{
    [SerializeField] private ShadowCollider platformMeasure;
    [SerializeField] private GameObject platform;

    private void Update()
    {
        float Distance = platformMeasure.topVertice.z - platform.transform.position.z;
        if (Distance < 0)
        {
            Distance = -Distance;
        }

        if (Distance > 15)
        {
            Distance = 15f;
        }
        else if (Distance < -15)
        {
            Distance = 0;
        }
        
        
        platform.transform.localScale = new Vector3(platform.transform.localScale.x, platform.transform.localScale.y, Distance);
    }

}
