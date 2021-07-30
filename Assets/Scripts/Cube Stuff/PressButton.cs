using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] bool pressing = false;
    public GameObject button;
    public GameObject wall;
    public Animator anim;
    public Animator anim2;
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
            anim2.SetBool("IsPressing", false);
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

        anim2.SetBool("IsPressing", true);
    }
    void Red()
    {
        button.GetComponent<Renderer>().material.color = Color.red;
    }
}
