using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "RangeCollider Preset", menuName = "ScriptablesObj/RangeCollider Preset")]
public class RangeColliderPreset : ScriptableObject
{
    public float minTime, maxTime;
    public bool isCollidable;
}
