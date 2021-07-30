using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public CharacterController player;
    public Transform receiver;
    public GameObject box;
    private bool Overlap = false;
    private bool Overlap2 = false;

    // Update is called once per frame
    void Update()
    {
        if (Overlap)
        {
            Vector3 pToP = player.transform.position - transform.position;
            float dotProd = Vector3.Dot(transform.up, pToP);
            
            if(dotProd < 0f)
            {
                float rotDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                
                player.transform.Rotate(Vector3.up, rotDiff);

                Vector3 posOffset = Quaternion.Euler(0f, rotDiff, 0f) * pToP;
                player.enabled = false;
                player.transform.position = receiver.position + posOffset;
                player.enabled = true;
                Overlap = false;
            }
        }
        if (Overlap2)
        {
            Vector3 pToP = box.transform.position - transform.position;
            float dotProd = Vector3.Dot(transform.up, pToP);

            if (dotProd < 0f)
            {
                float rotDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotDiff += 180;
                box.transform.Rotate(Vector3.up, rotDiff);

                Vector3 posOffset = Quaternion.Euler(0f, rotDiff, 0f) * pToP;
                box.transform.position = receiver.position + posOffset;
                Overlap2 = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Overlap = true;
        }
        if(other.tag == "Box")
        {
            box = other.gameObject;
            Overlap2 = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Overlap = false;
        }
        if (other.tag == "Box")
        {
            Overlap2 = false;
        }
    }
}
