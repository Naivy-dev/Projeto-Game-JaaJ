using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLightSensitive : MonoBehaviour
{
    [SerializeField] FlashLightMechanic flashlight;
    [SerializeField] BoxCollider objectCollider;
    [SerializeField] float coolDownTime;

    public Material[] material;
    Renderer rend;

    private float nextTime = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];        
    }

    void Update()
    {        
        if (Time.time > nextTime)
        {
            if (this.tag == "lightAble")
            {
                if (flashlight.hitInfo.collider == objectCollider)
                {
                    nextTime = Time.time + coolDownTime;
                    objectCollider.isTrigger = false;
                    rend.sharedMaterial = material[0];
                }
                else
                {
                    nextTime = Time.time + coolDownTime;
                    objectCollider.isTrigger = true;
                    rend.sharedMaterial = material[1];
                }
            }
            else if(this.tag == "unLightable")
            {
                if (flashlight.hitInfo.collider == objectCollider)
                {
                    nextTime = Time.time + coolDownTime;
                    objectCollider.isTrigger = true;
                    rend.sharedMaterial = material[1];
                }
                else
                {
                    nextTime = Time.time + coolDownTime;
                    objectCollider.isTrigger = false;
                    rend.sharedMaterial = material[0];
                }
            }
            
        }
        
    }
}
