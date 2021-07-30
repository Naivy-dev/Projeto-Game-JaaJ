using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSensitive : MonoBehaviour
{
    [SerializeField] FlashlightMechanic flashlight;
    [SerializeField] MeshCollider objectCollider;
    [SerializeField] float coolDownTime;
    [SerializeField] private Animator anim;

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
                    gameObject.layer = 7;
                    rend.sharedMaterial = material[0];
                    anim.SetBool("Switch reverso", true);           
                }
                else
                {                    
                    objectCollider.isTrigger = true;
                    gameObject.layer = 0;
                    anim.SetBool("Switch reverso", false);
                }
            }
            else if (this.tag == "unLightable")
            {
                if (flashlight.hitInfo.collider == objectCollider)
                {
                    nextTime = Time.time + coolDownTime;
                    objectCollider.isTrigger = true;
                    gameObject.layer = 0;
                    anim.SetBool("Switch", true);
                    //rend.sharedMaterial = material[1];
                }
                else
                {                    
                    objectCollider.isTrigger = false;
                    gameObject.layer = 7;
                    rend.sharedMaterial = material[0];
                    anim.SetBool("Switch", false);
                    
                }
            }

        }

    }

    
    public void ChangeMaterial(string alo)
    {
        if (alo == "teu cu")
            rend.sharedMaterial = material[1];
    }
}
