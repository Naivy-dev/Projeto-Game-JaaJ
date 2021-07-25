using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeColliderManager : MonoBehaviour
{
    [SerializeField] private RangeColliderPreset Preset;
    [SerializeField] private LightingManager Lighting;

    private void Update()
    {
   
        if (Preset.minTime < Lighting.TimeOfDay && Preset.maxTime > Lighting.TimeOfDay)
        {
            Preset.isCollidable = true;         
        }
        else
        {
            Preset.isCollidable = false;
        }
    }

}
