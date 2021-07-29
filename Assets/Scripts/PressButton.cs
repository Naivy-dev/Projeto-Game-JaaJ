using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] bool pressing = false;
    public GameObject button;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if (pressing)
        {
            anim.SetBool("IsPressing", true);
        }
        else
        {
            anim.SetBool("IsPressing", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        pressing = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        pressing = false;
    }
    void Green()
    {
        button.GetComponent<Renderer>().material.color = Color.green;
    }
    void Red()
    {
        button.GetComponent<Renderer>().material.color = Color.red;
    }
}
