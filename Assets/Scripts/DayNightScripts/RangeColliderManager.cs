using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeColliderManager : MonoBehaviour
{
    [SerializeField] private RangeColliderPreset Preset;
    [SerializeField] private LightingManager Lighting;

    public GameObject Cube;

    private void Update()
    {
        Debug.Log(Lighting.TimeOfDay);
        Debug.Log(Preset.minTime);
        Debug.Log(Preset.maxTime);

        if (Preset.minTime < Lighting.TimeOfDay && Preset.maxTime > Lighting.TimeOfDay)
        {
            Preset.isCollidable = true;
            //Cube.transform.position = new Vector3(Cube.transform.position.x,0.5f,Cube.transform.position.z);
        }
        else
        {
            //Cube.transform.position = new Vector3(Cube.transform.position.x, -0.6f, Cube.transform.position.z);
            Preset.isCollidable = false;
        }
    }

}
