using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScaleManager : MonoBehaviour
{
    [SerializeField] private ShadowCollider platformMeasure;
    [SerializeField] private GameObject platform;
    [SerializeField] private LightingManager Sun;
    [SerializeField] private float range;
    float Distance;
    float Scale;
    private void Update()
    {
        Distance = platformMeasure.topVertice.z - platform.transform.position.z;
        Scale = Distance;
        if (Distance < 0)
        {
            Scale = -Distance;
        }

        if (Distance > range)
        {
            Scale = range;
        }
        else if (Distance < -range)
        {
            Scale = 0;
        }

        if (Sun.TimeOfDay < 5 || Sun.TimeOfDay > 18)
        {
            Scale = 0;
        }


        platform.transform.localScale = new Vector3(platform.transform.localScale.x, platform.transform.localScale.y, Scale);
    }
}
